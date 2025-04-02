function exportToExcelRequest(data, displayFields) {
	//var data = @Html.Raw(Json.Serialize(Model.ListPerson));
	//var displayFields = '@Model.DisplayFields';
	console.log(data);
	if (!data || data.length === 0) {
		alert("No data to export.");
		return;
	}

	$.ajax({
		url: `/Rookies/ExportToExcel?displayFields=${encodeURIComponent(displayFields)}`,
		type: 'POST',
		contentType: 'application/json',
		data: JSON.stringify(data),
		xhrFields: {
			responseType: 'blob' // Important: Tell jQuery to expect a binary response
		},
		success: function (response, status, xhr) {
			// Get filename from Content-Disposition header if available
			var filename = 'ExportData.xlsx';
			var disposition = xhr.getResponseHeader('Content-Disposition');
			if (disposition && disposition.indexOf('attachment') !== -1) {
				var filenameRegex = /filename[^;=\n]*=((['"]).*?\2|[^;\n]*)/;
				var matches = filenameRegex.exec(disposition);
				if (matches != null && matches[1]) {
					filename = matches[1].replace(/['"]/g, '');
				}
			}

			var blob = new Blob([response], {
				type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet'
			});
			var link = document.createElement('a');
			link.href = URL.createObjectURL(blob);
			link.download = filename;
			document.body.appendChild(link);
			link.click();
			document.body.removeChild(link);
			URL.revokeObjectURL(link.href);
		},
		error: function (xhr, status, error) {
			alert(`Error: ${xhr.status} - ${error}`);
		}
	});
}

function saveData(url, method) {
	var data = {
		firstName: $("#FirstName").val(),
		lastName: $("#LastName").val(),
		dateOfBirth: $("#DateOfBirth").val(),
		gender: $("#Gender").val() == "0" ? 0 : 1,
		phoneNumber: $("#PhoneNumber").val(),
		birthPlace: $("#BirthPlace").val(),
		isGraduated: $("#IsGraduated").prop('checked')
	}
	console.log("data:", data);
	$.ajax({
		url: url,
		type: method,
		contentType: 'application/json',
		data: JSON.stringify(data),
		success: function (response, status, xhr) {
			localStorage.setItem("titleToast", "Data updated");
			localStorage.setItem("messageToast", "Data updated Successfully!");
			window.location.href = "/Rookies"
		},
		error: function (xhr, status, error) {

		}
	});
}

//DELETE
function deletePerson(id, isRedirect=false) {
	console.log(id)
	var toastLiveExample = document.getElementById('liveToast');
	$('#btn-remove').click(function () {
		$.ajax({
			url: `/Rookies/Delete?id=${id}`,
			type: 'DELETE',
			contentType: 'application/json',
			success: function (response, status, xhr) {
				localStorage.setItem("titleToast", "Delete");
				localStorage.setItem("messageToast", "Deleted successfully!");
				if (isRedirect) window.location.href="/Rookies"
				$(`#row-${id}`).remove();
				var toast = new bootstrap.Toast(toastLiveExample)
				$("#toastTitle").text("Delete");
				$("#toastMessage").text("Deleted successfully!");
				toast.show()
			},
			error: function (xhr, status, error) {

			}
		});
	});

}