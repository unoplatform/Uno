Set-PSDebug -Trace 1

$external_docs =
@(
    @("https://github.com/unoplatform/uno.wasm.bootstrap", "uno.wasm.bootstrap", "44bb961720b3ae27613b68f7da96ed2a406ef4a8"),
    @("https://github.com/unoplatform/uno.themes", "uno.themes", "a5ba64eb6967ea2b315adeda77eea452359bb13e"),
    @("https://github.com/unoplatform/uno.toolkit.ui", "uno.toolkit.ui", "d512cc88a541b2da858e7013b81d8a1b83d89272"),
    @("https://github.com/unoplatform/uno.check", "uno.check", "4ac7f583dc32283474613397472a0333ea415e1f"),
    @("https://github.com/unoplatform/uno.xamlmerge.task", "uno.xamlmerge.task", "a6d2efa69e24e8280c38300b5c1b7a8f2033f9f9"),
    @("https://github.com/unoplatform/figma-docs", "figma-docs", "a740582020509f9947fbf991628075a4717bff0a"),
    @("https://github.com/unoplatform/uno.extensions", "uno.extensions", "fedd58366a66fb30d38c3e9676f9947b055836e6")
)

$ErrorActionPreference = 'Stop'

function Assert-ExitCodeIsZero()
{
    if ($LASTEXITCODE -ne 0)
    {
        throw "Exit code must be zero."
	}
}

mkdir articles\external -ErrorAction Continue
pushd articles\external

# ensure long paths are supported on Windows
git config --global core.longpaths true

# Heads - Release
for($i = 0; $i -lt $external_docs.Length; $i++)
{
    $repoUrl=$external_docs[$i][0]
    $repoPath=$external_docs[$i][1]
    $repoBranch=$external_docs[$i][2]

    echo "Cloning $repoPath ($repoUrl@$repoBranch)"

    git clone $repoUrl $repoPath
    Assert-ExitCodeIsZero

    pushd $repoPath
    git checkout $repoBranch
    Assert-ExitCodeIsZero
    popd
}

popd
