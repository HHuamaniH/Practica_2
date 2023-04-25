var ckeditorConfig = {
    ckfinder: {
        uploadUrl: urlLocalSigo + '/General/Editor/ckEditor?command=QuickUpload&type=Files&responseType=json'
    },
    toolbar: {
        items: [
            //'heading',
            //'|',
            'fontSize',
            'fontFamily',
            '|',
            'bold',
            'italic',
            'underline',
            'strikethrough',
            '|',
            'fontColor',
            'removeFormat',
            'highlight',
            '|',
            'alignment',
            'pageBreak',
            'horizontalLine',
            '|',
            'numberedList',
            'bulletedList',
            '|',
            'indent',
            'outdent',
            '|',
            //'todoList',
            'link',
            'blockQuote',
            //'imageUpload',
            'insertImage',
            'insertTable',
            //'mediaEmbed',
            '|',
            'undo',
            'redo',
            //'MathType',
            //'ChemType',
            //'specialCharacters'//, 'fileExplorer'
        ],
    },
    //language: 'es',

    image: {
        styles: [
            'alignLeft', 'alignCenter', 'alignRight'
        ],
        resizeOptions: [
            {
                name: 'resizeImage:original',
                label: 'Original',
                value: null
            },
            {
                name: 'resizeImage:50',
                label: '50%',
                value: '50'
            },
            {
                name: 'resizeImage:75',
                label: '75%',
                value: '75'
            },
            {
                name: 'resizeImage:100',
                label: '100%',
                value: '100'
            }
        ],
        toolbar: [
            'imageStyle:alignLeft', 'imageStyle:alignCenter', 'imageStyle:alignRight',
            '|',
            'resizeImage',
            '|',
            'imageTextAlternative'
        ]
    },
    table: {
        contentToolbar: [
            'tableColumn', 'tableRow', 'mergeTableCells',
            'tableProperties', 'tableCellProperties'
        ],
    },
    htmlSupport: {
        allow: [
            {
                name: /.*/,
                attributes: true,
                classes: true,
                styles: true
            }
        ]
    }
};
