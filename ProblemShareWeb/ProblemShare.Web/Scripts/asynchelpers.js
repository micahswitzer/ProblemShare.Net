/*
    File: AsyncHelpers.ts
    written by Micah Switzer for ProblemShare

    Description: Various functions to aide in asyncronous navigation and page operations
*/
(($) => {
    $(() => {
        // Async page loads
        $(".main-menu > li > a, a[data-async='true']").on("click", function (e) {
            if ($(this).data("async") == false)
                return true; // Quick hack, change to using CSS selector syntax
            e.preventDefault();
            const location = this.href;
            $.ajax({
                url: this.href + "?partial=true",
                type: "GET",
                async: true,
                success(data, result, jqXHR) {
                    window.history.pushState(null, "ProblemShare", location);
                    document.getElementById("content").firstElementChild.innerHTML = data;
                },
                error() {
                    window.location.href = location; // If there's an issue, revert to normal redirection
                }
            });
            return false;
        });
        // Custom foreach function for non-explicit arrays
        function forEach(lst, exp) {
            for (let i = 0; i < lst.length; i++) {
                exp(lst[i]);
            }
        }
        $.fn.uploadFile = function (settings) {
            var formData = new FormData();
            // Iterate through every possible file
            this.each((i, elem) => {
                const files = elem.files;
                forEach(files, (file) => {
                    formData.append("files[]", file, file.name);
                });
            });
            // Send the data using (almost) raw Ajax
            const oReq = new XMLHttpRequest();
            oReq.onload = function () { settings.success(this.response); };
            oReq.open("post", settings.url);
            oReq.send(formData);
            return this;
        };
        function degToRad(a) {
            return (a / 180) * Math.PI;
        }
        $.fn.backgroundAnimation = function (spacing, thickness, speed, color1, color2) {
            const canvas = this[0];
            if (!canvas) {
                console.warn("backgroundAnimation: Element is not an HTMLCanvasElement");
                return this;
            }
            let w, h, len, prog = 0;
            let numToGen, boxTransX, boxTransY;
            const ang = degToRad(45);
            const context = canvas.getContext("2d");
            function calcDims() {
                w = document.body.clientWidth;
                h = document.body.clientHeight;
                len = (thickness + h) * Math.SQRT2;
                numToGen = ((w + h) / spacing) + 1;
                boxTransX = -(thickness / 2);
                boxTransY = Math.SQRT2 * boxTransX;
                canvas.width = w;
                canvas.height = h;
            }
            function animate(p) {
                context.beginPath();
                context.rect(0, 0, w, h);
                context.fillStyle = color1;
                context.fill();
                context.closePath();
                for (let i = -1; i < numToGen; i++) {
                    const trans = i * spacing + p;
                    context.translate(trans, 0);
                    context.rotate(ang);
                    context.beginPath();
                    context.rect(boxTransX, boxTransY, thickness, len);
                    context.fillStyle = color2;
                    context.fill();
                    context.closePath();
                    context.rotate(-ang);
                    context.translate(-trans, 0);
                }
            }
            calcDims();
            this.resize(calcDims);
            setInterval(() => {
                prog++;
                if (prog >= spacing) {
                    prog = 0;
                }
                animate(prog);
            }, 1000 / speed);
            return this;
        };
        $("label[data-upload-url]").each((idx, elem) => {
            let $this = $(elem);
            $this.change(() => $this.children("input[type='file']").uploadFile({
                url: $this.data("uploadUrl"),
                success: (x) => eval($this.data("uploadSuccess") + "(" + x + ")")
            }));
        });
    });
})(jQuery);
//# sourceMappingURL=asynchelpers.js.map