// https://github.com/rafrex/spa-github-pages
(function (l) {
    if (l.search) {
        var q = {};
        l.search.slice(1).split('&').forEach(function (v) {
            var a = v.split('=');
            q[a[0]] = a.slice(1)
                .join('=')
                .replace(/~and~/g, '&');
        });
        if (q.p !== undefined) {
            // Support for non-main repo GitHub pages
            var repoName = l.pathname.slice(0, -1);
            if (q.p !== undefined) {
                q.p = q.p.replace(`${repoName}/`, '/');
            }

            window.history.replaceState(null, null,
                repoName + (q.p || '') +
                (q.q ? ('?' + q.q) : '') +
                l.hash
            );
        }
    }
}(window.location))