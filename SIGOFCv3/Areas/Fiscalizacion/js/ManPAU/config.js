var ckeditorConfig = {
	ckfinder: {
		uploadUrl: urlLocalSigo + '/Supervision/ManInforme/ckEditor?command=QuickUpload&type=Files&responseType=json'
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
	}
};

let fnDate = {
	toDate: function (value) {
		if (typeof value === 'string') {
			var a;
			var paternDefault = /^(\/Date\(-?(\d+)(-\d+)?\)\/)$/;
			var paternString = /^((\d{1,2})[/\|-](\d{1,2})[/\|-](\d{4})\s?(\d{2})?:?(\d{2})?:?(\d{2})?)$/;
			var patternISO = /(\d{4})-(\d{2})-(\d{2})T(\d{2}):(\d{2}):(\d{2})/;
			//"2018-09-12T16:00:42.310Z"
			if (paternDefault.test(value)) {
				a = paternDefault.exec(value);
				if (a) {
					a.shift();
					return new Date(+a[1]);
				}
			}
			else if (paternString.test(value)) {
				a = paternString.exec(value);
				if (a) {
					a.shift();
					return new Date(parseInt(a[3]), parseInt(a[2]) - 1, parseInt(a[1]), parseInt(a[4] || 0), parseInt(a[5] || 0), parseInt(a[6] || 0));
				}
			}
			else if (patternISO.test(value)) {
				a = patternISO.exec(value);
				if (a) {
					//a.shift();
					return new Date(parseInt(a[1]), parseInt(a[2]) - 1, parseInt(a[3]),
						parseInt(a[4]), parseInt(a[5]), parseInt(a[6]));
				}
			}
		}
		return value;
	},
	text: function (value) {
		if (!value) return;
		return fnDate.toDate(value).toISOString().substr(0, 10).split('-').reverse().join('/');
	},
	text_long: function (d) {
		let text = '';
		if (d) {
			let f = fnDate.toDate(d);
			text = `${f.getDate()} de ${f.toLocaleDateString('es', { month: 'long' })} del ${f.getFullYear()}`;
		}
		return text;
	}
};

/**
 * plugin
 */

(function ($) {
	$.fn.getUnformattedText = function () {
		return $.trim($(this).html()
			.split(/\>[\n\t\s]*\</g).join('><')
			.split(/[\n\t]*/gm).join(''));
	}
})(jQuery);

/**
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
	//template: `<textarea class="form-control form-control-sm" :value="value" v-on:input="updateValue($event.target.value)"></textarea>`,
	template: `<div class="ckeditor-inf"><div class="toolbar-container"></div><div class="editor-container"><div class="editor"></div></div></div>`,
	data: {
		instance: null,
		value: null
	},
	props: ['value', 'orientation', 'disabled'],
	mounted: function () {
		let self = this;
		if (self.orientation) $(self.$el).addClass(self.orientation);

		DecoupledDocumentEditor.create($(this.$el).find(".editor")[0], ckeditorConfig).then(editor => {
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