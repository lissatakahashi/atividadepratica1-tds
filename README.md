<h1>Atividade Prática 1</h1>
<p>Esta é a atividade prática 1 da disciplina de Tecnologia em Desenvolvimento de Sistemas. Ela consiste em desenvolver uma API RESTful utilizando Minimal API do .NET Core que permita o cadastro, a consulta, a atualização e a exclusão de produtos. Cada produto deve ter as seguintes propriedades:</p>
<ul>
  <li>Id: inteiro;</li>
  <li>Nome: string;</li>
  <li>Preço: decimal;</li>
  <li>Quantidade: inteiro.</li>
</ul>
<p>A API deve ser capaz de armazenar os produtos em uma lista em memória, sem persistência em um banco de dados. A lista deve ser inicializada com alguns produtos para testes. A sugestão é que comece implementando as rotas básicas (GET, POST, PUT, DELETE) para a entidade Produto e, em seguida, possam adicionar outras funcionalidades à API, como validação de dados e documentação com Swagger.</p>
<p>Algumas validações de dados foram implementadas nesta atividade, que são a verificação se a quantidade de produtos que o usuário inseriu é maior que zero, e também a verificação para ver se o preço do produto foi colocado com duas casas decimais.</p>
