/*!
 * googoose 1.0.2
 * https://github.com/aadel112/googoose/js/jquery.googoose.js
 * @license Apache 2.0
 *
 * Copyright (C) 2016 - aadel112.com - A project by Aaron Adel    
 */
(function ($) {

    $.fn.googoose = function (options, callback) {

        var GG = this;
        var now = new Date().getTime();
        var proto = new RegExp(/^(http|https|file):/);
        var ab = new RegExp(/^\//);

        GG.finish = function () {
            if (options.debug)
                GG.debug_fn('finish action');
            if (callback) {
                var blob = new Blob([options.html], {
                    type: 'application/msword'
                });
                callback(null, blob);
            } else {
                GG.saveHtmlAsFile(options.filename, options.html);
            }
        }

        options = $.extend({
            // These are the defaults.		
            area: 'div.googoose-wrapper',
            margins: '1.0in',
            zoom: '75',
            filename: 'Doc1_' + now + '.doc',
            size: '8.2in 11.7in',
            display: 'Print',
            lang: 'es-PE',
            toc: 'div.googoose.toc',
            pagebreak: 'div.googoose.break',
            header: null,
            headerarea: 'div.googoose.header',
            footer: null,
            footerarea: 'div.googoose.footer',
            headerid: 'googoose-header',
            footerid: 'googoose-footer',
            footeridfirst: null, //ff1
            footeridland: 'googoose-footer-landscape',
            headermargin: '.5in',
            footermargin: '.5in',
            currentpage: 'span.googoose.currentpage',
            totalpage: 'span.googoose.totalpage',
            finishaction: GG.finish,
            html: null,
            initobj: document,
            debugtype: 'alert',
            debug: 0
        }, options);
        GG.options = options;

        GG.debug_fn = function (args) {
            options.debugtype == 'console' ? console.log(args) : alert(args);
        }

        //http://stackoverflow.com/questions/18755750/saving-text-in-a-local-file-in-internet-explorer-10
        GG.saveHtmlAsFile = function (
            fileNameToSaveAs, textToWrite
        ) {
            /* Saves a text string as a blob file*/
            var ie = navigator.userAgent.match(/MSIE\s([\d.]+)/),
                ie11 = navigator.userAgent.match(/Trident\/7.0/) && navigator.userAgent.match(/rv:11/),
                ieEDGE = navigator.userAgent.match(/Edge/g),
                ieVer = (ie ? ie[1] : (ie11 ? 11 : (ieEDGE ? 12 : -1)));

            if (ie && ieVer < 10) {
                console.log("No blobs on IE ver<10");
                return;
            }

            var textFileAsBlob = new Blob([textToWrite], {
                type: 'application/msword'
            });

            if (ieVer > -1) {
                window.navigator.msSaveBlob(textFileAsBlob, fileNameToSaveAs);

            } else {
                var downloadLink = document.createElement("a");
                downloadLink.download = fileNameToSaveAs;
                downloadLink.href = window.URL.createObjectURL(textFileAsBlob);
                downloadLink.onclick = function (e) { document.body.removeChild(e.target); };
                downloadLink.style.display = "none";
                document.body.appendChild(downloadLink);
                downloadLink.click();
            }
        }

        // http://stackoverflow.com/questions/7394748/whats-the-right-way-to-decode-a-string-that-has-special-html-entities-in-it
        GG.decodeHtmlEntity = function (str) {
            return str.replace(/&#(\d+);/g, function (match, dec) {
                return String.fromCharCode(dec);
            });
        }


        GG.translate_mso_features = function (html) {
            if (options.debug)
                GG.debug_fn('GG.translate_mso_features');

            html = GG.decodeHtmlEntity(html);
            html = GG.remove_bad_tags(html);
            html = GG.convert_pagebreaks(html);
            html = GG.convert_toc(html);
            html = GG.convert_hdrftr(html);
            html = GG.convert_imgs(html);

            return html;
        }

        GG.remove_bad_tags = function (html) {
            if (options.debug)
                GG.debug_fn('GG.remove_bad_tags');
            var thtml = $(html);


            thtml.find('noscript').each(function () {
                $(this).replaceWith('');
            });
            thtml.each(function () {
                if ($(this).is(':hidden')) {
                    $(this).remove();
                }
            });

            html = thtml[0].outerHTML;
            return html;
        }

        GG.convert_pagebreaks = function (html) {
            if (options.debug)
                GG.debug_fn('GG.convert_pagebreaks');
            //user decides in html what will be a page break in word, this converts to a page break
            if (options.pagebreak) {
                var thtml = $(html);
                thtml.find(options.pagebreak).replaceWith(GG.get_pagebreak());
                html = thtml[0].outerHTML;
            }
            return html;
        }

        GG.convert_toc = function (html) {
            if (options.debug)
                GG.debug_fn('GG.convert_toc');
            //user determines in html what will be the toc in word
            if (options.toc && $(options.toc).length) {
                var thtml = $(html);
                thtml.find(options.toc).replaceWith(GG.get_toc_contents());
                html = thtml[0].outerHTML;
            }
            return html;
        }

        GG.convert_hdrftr = function (html) {
            if (options.debug)
                GG.debug_fn('GG.convert_hdrftr');
            var hvis = options.headerarea && $(options.headerarea).length;
            var fvis = options.footerarea && $(options.footerarea).length;
            if (hvis || fvis) {
                html = GG.convert_totalpage(html);
                html = GG.convert_currentpage(html);
            }

            var thtml = $(html);
            if (hvis) {
                thtml.find(options.headerarea).replaceWith(GG.headerstart() + thtml.find(options.headerarea).html() + GG.headerend());
                html = thtml[0].outerHTML;
            }
            if (fvis) {
                thtml.find(options.footerarea).replaceWith(GG.footerstart() + thtml.find(options.footerarea).html() + GG.footerend())
                html = thtml[0].outerHTML;
            }
            return html;

        }

        GG.convert_imgs = function (html) {
            if (options.debug)
                GG.debug_fn('GG.convert_imgs');
            //make sure all standard images use absolute path 
            var thtml = $(html);
            imgs = thtml.find('img');
            imgs.each(function () {
                var src = $(this)[0].src;
                var l = window.location;
                var t = l.protocol + '//' + l.host + '/';
                if (proto.test(src)) {
                } else if (ab.test(src)) {
                    src = t + src;
                } else {
                    var p = l.path.replace('/\/[^\/.]+$/', '/');
                    src = t + p + src;
                }
                $(this).attr('src', src);
            });
            html = thtml[0].outerHTML;
            return html;
        }

        GG.convert_totalpage = function (html) {
            if (options.debug)
                GG.debug_fn('GG.convert_totalpage');
            if (options.totalpage && $(options.totalpage).length) {
                var thtml = $(html);
                thtml.find(options.totalpage).html('');
                thtml.find(options.totalpage).append(GG.get_total_page_number());
                html = thtml[0].outerHTML;
            }
            return html;
        }

        GG.convert_currentpage = function (html) {
            if (options.debug)
                GG.debug_fn('GG.convert_currentpage');
            if (options.currentpage && $(options.currentpage).length) {
                var thtml = $(html);
                thtml.find(options.currentpage).html('');
                thtml.find(options.currentpage).append(GG.get_page_number());
                html = thtml[0].outerHTML;
            }
            return html;
        }

        GG.get_pagebreak = function () {
            if (options.debug)
                GG.debug_fn('GG.get_pagebreak');
            return '<br clear=all style="mso-special-character:line-break;page-break-before:always">';
        }

        GG.headerstart = function () {
            var html = '';
            //html += '\n<table class="mso-hidden" border="0" cellspacing="0" cellpadding="0"><tr><td>';
            html += '<div style="mso-element:header" id="' + options.headerid + '">\n';
            html += '<p class="MsoHeader">\n';
            return html;
        }
        GG.headerend = function () {
            if (options.debug)
                GG.debug_fn('GG.headerend');
            return '</p></div>';
            //'</td></tr></table>\n';
        }

        GG.footerstart = function (footerid) {
            if (options.debug)
                GG.debug_fn('GG.footerstart');
            var html = '';
            html += '<table class="mso-hidden" border="0" cellspacing="0" cellpadding="0"><tr><td>';
            html += '<div style="mso-element:footer" id="' + footerid + '">';
            return html;
        }

        GG.footerend = function () {
            if (options.debug)
                GG.debug_fn('GG.footerend');
            return '</div></td></tr></table>\n';
        }

        GG.get_page_number = function () {
            if (options.debug)
                GG.debug_fn('GG.get_page_number');
            var html = '<!--[if supportFields]><span\n';
            html += 'class=MsoPageNumber><span style=\'mso-element:field-begin\'></span><span\n';
            html += 'style=\'mso-spacerun:yes\'> </span>PAGE <span style=\'mso-element:field-separator\'></span></span><![endif]--><span\n';
            html += 'class=MsoPageNumber><span style=\'mso-no-proof:yes\'>1</span></span><!--[if supportFields]><span\n';
            html += 'class=MsoPageNumber><span style=\'mso-element:field-end\'></span></span><![endif]-->';
            return html;
        }

        GG.get_total_page_number = function () {
            if (options.debug)
                GG.debug_fn('GG.get_total_page_number');
            var html = '<!--[if supportFields]><span class=MsoPageNumber><span \n';
            html += ' style=\'mso-element:field-begin\'></span> NUMPAGES <span style=\'mso-element:field-separator\'></span></span><![endif]--><span \n';
            html += ' class=MsoPageNumber><span style=\'mso-no-proof:yes\'>1</span></span><!--[if supportFields]><span \n'
            html += ' class=MsoPageNumber><span style=\'mso-element:field-end\'></span></span><![endif]-->\n';
            return html;
        }

        GG.get_toc_contents = function () {
            if (options.debug)
                GG.debug_fn('GG.get_toc_contents');
            var toc = '<p class=MsoToc1>\n';
            toc += '<!--[if supportFields]>\n';
            toc += '<span style=\'mso-element:field-begin\'></span>\n';
            toc += 'TOC \o "1-3" \\u \n';
            toc += '<span style=\'mso-element:field-separator\'></span>\n';
            toc += '<![endif]-->\n';
            toc += '<span style=\'mso-no-proof:yes\'>Table of content - Please right-click and choose "Update fields".</span>\n';
            toc += '<!--[if supportFields]>\n';
            toc += '<span style=\'mso-element:field-end\'></span>\n';
            toc += '<![endif]-->\n';
            toc += '</p>\n';

            return toc;
        }

        //TODO - figure out a way to simulate a right mpuse click, update fields


        GG.include_css = function (html) {
            if (options.debug)
                GG.debug_fn('GG.include_css');
            //adding any header information that may be pertinent in the copied html
            var tags = ['style', 'link'];
            for (i = 0; i < tags.length; ++i) {
                $(document).find(tags[i]).each(function () {
                    if (tags[i] != 'link' || ($(this).attr('rel') == 'stylesheet' && proto.test($(this).attr('href')))) {
                        html += ('\n' + $(this)[0].outerHTML + '\n');
                    }
                });
            }
            return html;
        }

        GG.html = function () {
            if (options.debug)
                GG.debug_fn('GG.html');
            if (!options.html && !$(options.area).length) {
                return null;
            }
            //             // fixes IE pre tag handling
            //             $('pre').each(function() {
            //                 $(this)[0].outerHTML = $(this)[0].outerHTML.replace(/\n/g, "<br />\n");
            //             });
            // adding the standard mso header 
            var html = '<html xmlns:v="urn:schemas-microsoft-com:vml" xmlns:o=\'urn:schemas-microsoft-com:office:office\' xmlns:w=\'urn:schemas-microsoft-com:office:word\' xmlns:m="http://schemas.microsoft.com/office/2004/12/omml" xmlns=\'http://www.w3.org/TR/REC-html40\'>\n';
            html += '<head>\n';
            html += '<meta charset=\'utf-8\'\n';
            html += '<!--[if gte mso 9]>\n';
            html += '<xml>\n';
            html += '<w:WordDocument>\n';
            html += ('<w:View>' + options.display + '</w:View>\n');
            html += ('<w:Zoom>' + options.zoom + '</w:Zoom>\n');
            //html += '<w:DoNotOptimizeForBrowser/>\n';
            html += '</w:WordDocument>\n';
            html += '<o:OfficeDocumentSettings>\n';
            html += '<o:AllowPNG/>\n';
            html += '</o:OfficeDocumentSettings>\n';
            html += '</xml>\n';
            html += '<![endif]-->\n';
            html += '';

            html = GG.include_css(html);
            //adding in mso style necessesities
            html += '<style>\n';
            //Se consideró una copia del footer para paginas horizontales para evitar problemas en la estructura
            html += '#' + options.headerid + ' {' +
                'margin: 0 0 0 20in;' +
                '}\n';
            html += '.mso-hidden { margin: 0in 0in 0in 900in; width: 1px; height: 1px; overflow: hidden; }\n';
            html += '<!--\n';
            html += '@page {' +
                'size:' + options.size + ';' +
                'margin:' + options.margins + ';' +
                '}\n';
            html += '@page Container {' +
                'mso-header-margin:' + options.headermargin + ';' +
                'mso-footer-margin:' + options.footermargin + ';' +
                'mso-header:' + options.headerid + ';' +
                'mso-footer:' + options.footerid + ';' +
                //'mso-title-page: yes;' +
                'mso-first-header: ' + options.headerid + ';' +
                ((options.footeridfirst) ? ('mso-first-footer:' + options.footeridfirst + ';') : '') +
                'mso-paper-source:0;' +
                '}\n';
            html += '.Container { page:Container; }\n';
            html += '@page portrait {' +
                'size:' + options.size + ';' +
                'mso-header-margin:' + options.headermargin + ';' +
                'mso-footer-margin:' + options.footermargin + ';' +
                'mso-first-header: ' + options.headerid + ';' +
                ((options.footeridfirst) ? ('mso-first-footer:' + options.footeridfirst + ';') : '') +
                'mso-header:' + options.headerid + ';' +
                'mso-footer:' + options.footerid + ';' +
                //'mso-title-page: yes;' +
                '}\n';
            html += '.portrait { page:portrait; }\n';
            html += '@page landscape {' +
                'size:' + options.size.split(' ').reverse().join(' ') + ';' +
                'mso-page-orientation: landscape;' +
                //'margin: ' + options.margins + ';' +
                'mso-header-margin:' + options.headermargin + ';' +
                'mso-footer-margin:' + options.footermargin + ';' +
                'mso-first-header: ' + options.headerid + ';' +
                ((options.footeridland) ? ('mso-first-footer:' + options.footeridland + ';') : '') +
                'mso-header: ' + options.headerid + ';' +
                'mso-footer: ' + options.footeridland + ';' +
                //'mso-title-page: yes;' +
                '}\n';
            html += '.landscape {page:landscape;}\n';
            html += 'body, table, table tr th, table tr td, p, ul, ol, span, strong, div { line-height: 1em; }\n';
            html += 'body, table { font-family: Arial; font-size: 10pt; }\n';
            html += 'ul, ol { margin-left: 25px; }\n';
            html += 'ul { list-style: disc; }\n';
            html += 'ul li, ol li { margin-bottom: 12px; }';
            html += '-->\n';
            html += '</style>\n';

            //close head
            html += '</head>\n';

            //start body
            html += ('<body lang=' + options.lang + '>\n');
            html += '<div class="Container">';

            // updated version plugin custom
            if (options.html) {
                html += options.html;

                if (options.header) html += GG.headerstart() + options.header + GG.headerend();
                if (options.footer) {
                    html += GG.footerstart(options.footerid) + options.footer + GG.footerend();
                    html += GG.footerstart(options.footeridland) + options.footer + GG.footerend();
                }

                if (options.currentpage) {
                    html = html
                        .replace(/(#CURRENTPAGE#|{{CURRENTPAGE}})/gi, GG.get_page_number())
                        .replace(/(#TOTALPAGES#|{{TOTALPAGES}})/gi, GG.get_total_page_number());
                }
            } else {
                //add area content
                if ($(options.initobj).is(options.area)) {
                    if (options.debug)
                        GG.debug_fn('is');
                    html += GG.translate_mso_features($(options.initobj)[0].outerHTML);
                } else {
                    if (options.debug)
                        GG.debug_fn('no is');
                    $(options.initobj).find(options.area).each(function () {
                        html += GG.translate_mso_features($(this)[0].outerHTML);
                    });
                }
            }

            html += '</div>';
            html += '</body>\n';

            //close doc
            html += '</html>\n';
            return html;
        }

        //execution
        if (options.debug) GG.debug_fn('googoose exec');

        options.html = GG.html();
        if (options.html && options.finishaction) {
            options.finishaction();
            //             console.log(options.html)
        }
        //         return options;
        return GG;
    };
}(jQuery));
