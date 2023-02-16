	(function($) {
		"use strict";


	$('#basicuse').jflickrfeed({
limit: 6,
qstrings: {
id: '133294431@N08'
},
itemTemplate: 
'<li>' +
'<a href="{{image_b}}"><img src="{{image_s}}" alt="{{title}}" /></a>' +
'</li>'
});
	})(jQuery);