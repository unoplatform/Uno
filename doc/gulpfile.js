const {dest, src, parallel, series, watch: gulpwatch} = require('gulp');
const notify = require('gulp-notify');
const autoprefixer = require('autoprefixer');
const sass = require('gulp-sass');
const uglify = require('gulp-uglify');
const concat = require('gulp-concat');
const postcss = require('gulp-postcss');
const gulpif = require('gulp-if');
const del = require('del');
const sourcemaps = require('gulp-sourcemaps');
const stripImportExport = require('gulp-strip-import-export');
const browserSync = require('browser-sync').create();
const exec = require('child_process').exec;

const assets = 'templates/uno';

let isDebug = false;
let isStrict = false;

function styles(done) {
    const output = isDebug ? 'nested' : 'compressed';

    src([`${assets}/vendor/*.css`])
        .pipe(dest(`${assets}/styles/`));

    src([`${assets}/**/*.scss`, `${assets}/**/*.sass`])
        .pipe(gulpif(isDebug, sourcemaps.init()))
        .pipe(
            sass({includePaths: ['./node_modules/'], outputStyle: output}).on(
                'error',
                sass.logError
            )
        )
        .pipe(postcss([autoprefixer]))
        .pipe(gulpif(isDebug, sourcemaps.mapSources(function (sourcePath) {
            return '../' + sourcePath;
        })))
        .pipe(concat('main.css'))
        .pipe(gulpif(isDebug, sourcemaps.write()))
        .pipe(dest(`${assets}/styles/`))
        .pipe(notify({message: 'CSS complete'}));

    done();
}

function docfx(done) {
    exec('docfx docfx.json', (err, stdout, stderr) => {

        // This will print the docfx errors
        if (isStrict) {
            console.log(stdout);
            console.log(stderr);
            // This will stop the execution of the task on error
            // At the moment there is an error on every build
            // This a workaround
            done(err);
        }
        done();
    });
}

function scripts(done) {
    src([`${assets}/main.js`])
        .pipe(gulpif(!isDebug, uglify()))
        .pipe(stripImportExport())
        .pipe(dest(`${assets}/styles/`));

    src([`${assets}/vendor/*.js`])
        .pipe(dest(`${assets}/styles/`));

    src([`${assets}/**/*.js`,
        `!${assets}/styles/*.js`,
        `!${assets}/conceptual.html.primary.js`,
        `!${assets}/main.js`,
        `!${assets}/vendor/*.js`])
        .pipe(gulpif(isDebug, sourcemaps.init()))
        .pipe(concat('docfx.js'))
        .pipe(gulpif(isDebug, sourcemaps.write()))
        .pipe(gulpif(!isDebug, uglify()))
        .pipe(dest(`${assets}/styles/`));

    done();
}

function watch() {
    // Watch .scss files
    gulpwatch([`${assets}/**/*.scss`, `${assets}/**/*.sass`], series([styles, docfx]))
        .on('change', browserSync.reload);

    // Watch docfx files
    gulpwatch([assets + '/**/*.tmpl', assets + '/**/*.tmpl.partial'], series([docfx]))
        .on('change', browserSync.reload);

    // Watch javascript files
    gulpwatch([`${assets}/**/*.js`, `!${assets}/styles/*.js`], series([scripts, docfx]))
        .on('change', browserSync.reload);
}

function serve() {
    browserSync.init({
        server: {
            baseDir: "_site"
        }
    });
}

async function clean(done) {

    await del([`${assets}/styles/**`,
        `!${assets}/styles`,
        `_site/styles/**`,
        `!_site/styles/`]);

    done();
}

function useDebug(done) {
    isDebug = true;
    done();
}

function useStrict(done) {
    isStrict = true;
    done();
}

const build = series(clean, styles, scripts, docfx);
const run = parallel(serve, watch);

exports.build = build;

exports.default = series(build, run);

exports.clean = series(clean);

exports.debug = series(useDebug, build, run);

exports.strict = series(useDebug, useStrict, build, run);
