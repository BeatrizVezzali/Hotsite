// @ts-nocheck
$(document).ready(
   function()
   {
	  $("#frmCadastro").submit(
		function(e)
		{
           e.preventDefault();
		   Cadastrar();
		}
	  )
   }
);

function Cadastrar()
{
	let parametros = {

		Nome: $("#nome").val(),
		Email: $("#email").val(),
		Mensagem: $("#mensagem").val()
	};

	$.post("Home/Cadastrar", parametros).done(
		function(data)
	{
		if(data.status == "Ok")
		{
           $("#frmCadastro").after(data.mensagem)
		   $("#frmCadastro").hide();
		}
		else
		{
			alert(data.mensagem);
		}
	})
    .fail(function()
	{
      alert("Ocorreu um erro");
	}
	)
};

	
