var fnDrawTable = function (options) {
	let _table = $("#" + options.id),
		_api;

	options.columns.forEach(function (col) {
		if (col.className) {
			col.class_td = col.class_th = col.className;
		}
	});

	if (_table.html()) {
		_table.DataTable().clear();
		_table.DataTable().destroy();
		_table.html('');
	}

	let _thead = $("<thead>", {
		"html": "<tr>" +
			options.columns.map(function (col) {
				return "<th class='" + (col.class_th || '') + "'>" + (col.title || col.render) + "</th>"
			}).join("") +
			"</tr>"
	});

	_table.append(_thead);

	let oOptions = $.extend({
		autoWidth: false,
		columnDefs: [
			//{ orderable: false, targets: 0 },
		],
		data: []
	}, options);

	oOptions.columns = options.columns.map(function (col) {
		return {
			mDataProp: null, //col.name -> Si colocas directo no necesita render
			render: function (data, type, full, meta) { return typeof col.render === 'function' ? col.render(data, meta) : data[col.render] !== null ? data[col.render] : '' },
			createdCell: function (td, cellData, rowData, row, col) {
				if (options.columns[col].class_td) $(td).addClass(options.columns[col].class_td);
				if (options.columns[col].renderValue && typeof options.columns[col].render === 'string') $(td).attr('data-render', options.columns[col].render);
				if (typeof options.columns[col].click === 'function') {
					$(td).click(function (evt) {
						let key = typeof options.columns[col].render === 'string' ? options.columns[col].render: '';
						options.columns[col].click(cellData, key, options.columns[col].params, evt.currentTarget);
					});
				}
			}
		}
	});

	if (typeof oOptions.rowClick === 'function') {
		_table.on('click', 'tbody tr', function (e) {
			var data = _api.row(this).data();
			oOptions.rowClick(data);
			return !0;
		});
	}

		
	_api = _table.DataTable(oOptions);

	//_table.css('width', '100%');
	//_dt.rows.add(res).draw();

	return _api;
}