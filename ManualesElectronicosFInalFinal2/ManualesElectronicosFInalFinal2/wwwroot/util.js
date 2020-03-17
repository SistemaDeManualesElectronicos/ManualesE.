function showlogout() {
    $("#logout").load("poplogout.html");
}

$(document).ready(function () {
	if (sessionStorage.curpos) {
		$("main").scrollTop(sessionStorage.curpos);
		sessionStorage.removeItem("curpos");
	}

	$(".cancel").click(function () {
		sessionStorage.curpos = $("main").scrollTop();
		window.location.reload();
	});

	$(".formAjax").submit(function (e) {
		e.preventDefault();

		var actionUrl = $(this).attr("action");
		$(".error").text("");

		sessionStorage.curpos = $("main").scrollTop();

		$.post(actionUrl, $(this).serialize(), function (res) {
			if (res == true) {
				window.location.reload();
			} else {
				$(".error").text(res);
			}
		});
	});

});
