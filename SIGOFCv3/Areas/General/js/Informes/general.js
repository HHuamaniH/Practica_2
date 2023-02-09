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
