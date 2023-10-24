﻿/**
 * Componentes VUE
 */

Vue.component('date-picker', {
    template: `<input type="text" class="form-control" v-bind:value="value" />`,
    props: ['value'],
    mounted: function () {
        let self = this;
        let dp = $(this.$el).datepicker({
            format: 'dd/mm/yyyy',
            autoclose: true,
            language: 'es',
        });

        dp.on('change', function (e) {
            self.$emit('input', e.target.value);
        });
    },
    //watch: {
    //    value(newVal) {
    //        console.log(newVal, 'Nuevo valor setear');
    //        let d = new Date(newVal);
    //        if (d instanceof Date && !isNaN(d)) $(this.$el).datepicker('setDate', d);
    //    }
    //},

    //beforeDestroy: function () {
    //    $(this.$el).datepicker('hide').datepicker('destroy');
    //}
});

Vue.component('editor', {    
    template: `<div class="ckeditor-inf">
                   <div class="toolbar-container"></div>
                   <div class="editor-container">
                      <div class="editor"></div>
                      <slot></slot>
                   </div>
               </div>`,
    data: {
        instance: null,
        value: null
    },
    props: ['value', 'orientation', 'disabled'],
    mounted: function () {
        let self = this;
        if (self.orientation) $(self.$el).addClass(self.orientation);

        // NEW VERSION
        /*const watchdog = new CKSource.EditorWatchdog();

        window.watchdog = watchdog;

        watchdog.setCreator((element, config) => {
            return CKSource.Editor
                .create(element, config)
                .then(editor => {
                    self.instance = editor;

                    // Set a custom container for the toolbar.
                    $(this.$el).find('.toolbar-container').append(editor.ui.view.toolbar.element);
                    //$(this.$el).find('.ck-toolbar').addClass('ck-reset_all');

                    let editor_changed = false;

                    //Cuando cambia el contenido
                    editor.model.document.on('change:data', () => { editor_changed = true; });

                    editor.ui.focusTracker.on('change:isFocused', (evt, name, isFocused) => {
                        if (!isFocused && editor_changed) {
                            editor_changed = false;
                            self.updateValue(editor.getData());
                        }
                    });

                    //Valor inicial
                    if (self.value) {
                        self.instance.setData(self.value);
                        self.updateValue(self.value);
                    }

                    return editor;
                })
        });

        watchdog.setDestructor(editor => {
            // Set a custom container for the toolbar.
            $(this.$el).find('.toolbar-container').remove(editor.ui.view.toolbar.element);

            return editor.destroy();
        });


        watchdog
            .create($(this.$el).find(".editor")[0], ckeditorConfig);*/

        DecoupledDocumentEditor.create($(this.$el).find(".editor")[0], window.ckeditorConfig || {}).then(editor => {
            self.instance = editor;

            //toolbarContainer
            $(self.$el).find(".toolbar-container").append(editor.ui.view.toolbar.element);

            //editor.model.document.on('change', (evt, data) => {
            //	this.updateValue(editor.getData())
            //});

            let editor_changed = false;

            //Cuando cambia el contenido
            editor.model.document.on('change:data', () => { editor_changed = true; });

            editor.ui.focusTracker.on('change:isFocused', (evt, name, isFocused) => {
                if (!isFocused && editor_changed) {
                    editor_changed = false;
                    self.updateValue(editor.getData());
                }
            });

            //Valor inicial
            if (self.value) {
                self.instance.setData(self.value);
                self.updateValue(self.value);
            }
        });
    },
    updated: function () {
        this.instance.setData(this.value || '');
    },
    methods: {
        updateValue: function (value) {
            this.$emit('input', value)
        }
    },
    watch: {
        value: function () {
            let html = this.instance?.getData();
            if (html !== this.value) {
                this.instance && this.instance.setData(this.value || '')
            }
        },
        disabled: function (val) {
            if (this.instance) {
                this.instance.isReadOnly = !!val;
            }
        }
    }
});

Vue.component("data-table", {
    template: '<table class="table"></table>',
    props: ["options", "data", "rowTmpl"],
    mounted: function () {
        var self = this;

        var default_options = {
            bAutoWidth: false,
            paging: true,
            lengthChange: false,
            searching: false,
        };

        default_options = $.extend(default_options, self.options);

        //let tmpl = document.getElementById(self.rowTmpl);
        default_options.fnRowCallback = function (row, data, displayIndex, displayIndexFull) {
            // Render the row template for this row.
            //ko.renderTemplate(binding.rowTemplate, data, null, row, "replaceChildren");
            //console.log(row, data, displayIndex, displayIndexFull);
            //$(row).html(tmpl.innerHTML);

            data.index = displayIndexFull;
            //render jquery.tmpl
            $(row).html($('<div>').append($(`#${self.rowTmpl}`).tmpl(data)).html());

            return row;
        };

        self.options = default_options;

        self.data_table = $(self.$el).DataTable(self.options);
        self.load_data();
    },
    watch: {
        data: {
            handler: function (value, old_value) {
                var self = this;
                self.load_data();
            },
            immediate: true
        }
    },
    methods: {
        load_data: function () {
            var self = this;

            if (!self.data || !self.data_table) {
                return;
            }

            self.data_table.clear().rows.add(self.data).draw();
        },
    }
});