
$(document).ready(function () {
	const titleToast = localStorage.getItem("titleToast");
	const messageToast = localStorage.getItem("messageToast");
	if (titleToast || messageToast) {
		localStorage.removeItem("titleToast");
		localStorage.removeItem("messageToast");
		var toastLiveExample = document.getElementById('liveToast');
		var toast = new bootstrap.Toast(toastLiveExample)
		$("#toastTitle").text(titleToast);
		$("#toastMessage").text(messageToast);
		toast.show()
	}

	$('#pageSize').change(function () {
		$("input[name='PageNumber']").val(1);
		$('form').submit();
	});

	$("#showFullName").change(function () {
		if ($(this).is(':checked')) {
			window.location.href = '/Rookies?DisplayFields=FullName'
		}
		else {
			window.location.href = '/Rookies?DisplayFields=*'
		}
	})

	$('input[name="BirthYearCompare"]').change(function () {
		const birthYear = $('#birthYear').val();
		const yearComparison = $('input[name="BirthYearCompare"]:checked').val();
		window.location.href = `/Rookies?BirthYear=${birthYear}&BirthYearCompare=${yearComparison}`
	})

	$('#gender').change(function () {
		$('form').submit();
	});

});