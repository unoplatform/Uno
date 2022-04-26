//Setup Affix
function renderAffix() {
    const hierarchy = getHierarchy();

    if (hierarchy && hierarchy.length > 0) {
        let html = '<h5 class="title">In This Article</h5>'
        html += formList(hierarchy, ['nav', 'bs-docs-sidenav']);

        $("#affix").empty().append(html);

        if ($('footer').is(':visible')) {
            $(".sideaffix").css("bottom", "70px");
        }

        $('#affix a').on('click', function (e) {
            const scrollspy = $('[data-spy="scroll"]').data()['bs.scrollspy'];
            const target = e.target.hash;
            if (scrollspy && target) {
                scrollspy.activate(target);
            }
        });

        const contribution = $('.contribution');
        const contributionDiv = contribution.get(0).outerHTML;
        contribution.remove();
        $('.sideaffix').append(contributionDiv);

    }

    function getHierarchy() {
        // supported headers are h1, h2, h3, and h4
        const $headers = $($.map(['h1', 'h2', 'h3', 'h4'], function (h) { return ".article article " + h; }).join(", "));

        // a stack of hierarchy items that are currently being built
        const stack = [];
        $headers.each(function (i, e) {
            if (!e.id) {
                return;
            }

            const item = {
                name: htmlEncode($(e).text()),
                href: "#" + e.id,
                items: []
            };

            if (!stack.length) {
                stack.push({ type: e.tagName, siblings: [item] });
                return;
            }

            const frame = stack[stack.length - 1];
            if (e.tagName === frame.type) {
                frame.siblings.push(item);
            } else if (e.tagName[1] > frame.type[1]) {
                // we are looking at a child of the last element of frame.siblings.
                // push a frame onto the stack. After we've finished building this item's children,
                // we'll attach it as a child of the last element
                stack.push({ type: e.tagName, siblings: [item] });
            } else {  // e.tagName[1] < frame.type[1]
                // we are looking at a sibling of an ancestor of the current item.
                // pop frames from the stack, building items as we go, until we reach the correct level at which to attach this item.
                while (e.tagName[1] < stack[stack.length - 1].type[1]) {
                    buildParent();
                }
                if (e.tagName === stack[stack.length - 1].type) {
                    stack[stack.length - 1].siblings.push(item);
                } else {
                    stack.push({ type: e.tagName, siblings: [item] });
                }
            }
        });
        while (stack.length > 1) {
            buildParent();
        }

        function buildParent() {
            const childrenToAttach = stack.pop();
            const parentFrame = stack[stack.length - 1];
            const parent = parentFrame.siblings[parentFrame.siblings.length - 1];
            $.each(childrenToAttach.siblings, function (i, child) {
                parent.items.push(child);
            });
        }
        if (stack.length > 0) {

            const topLevel = stack.pop().siblings;
            if (topLevel.length === 1) {  // if there's only one topmost header, dump it
                return topLevel[0].items;
            }
            return topLevel;
        }
        return undefined;
    }

    function htmlEncode(str) {
        if (!str) return str;
        return str
            .replace(/&/g, '&amp;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;');
    }

    function htmlDecode(str) {
        if (!str) return str;
        return str
            .replace(/&quot;/g, '"')
            .replace(/&#39;/g, "'")
            .replace(/&lt;/g, '<')
            .replace(/&gt;/g, '>')
            .replace(/&amp;/g, '&');
    }

    function cssEscape(str) {
        // see: http://stackoverflow.com/questions/2786538/need-to-escape-a-special-character-in-a-jquery-selector-string#answer-2837646
        if (!str) return str;
        return str
            .replace(/[!"#$%&'()*+,.\/:;<=>?@[\\\]^`{|}~]/g, "\\$&");
    }
}
