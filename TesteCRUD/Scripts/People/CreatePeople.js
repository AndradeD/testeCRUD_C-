function create() {
	var nome = $("#nome-people-value").val()
	var telefone = $("#telefone-people-value").val()

	var pessoa = {
		nome: nome,
		telefone: telefone
	}

	$.ajax({
		type: "POST",
		url: "/Home/Create",
		dataType: "json",
		success: function (msg) {
			if (msg) {
				alert("Somebody" + name + " was added in list !");
				location.reload(true);
			} else {
				alert("Cannot add to list !");
			}
		},

		data: pessoa
	});
}