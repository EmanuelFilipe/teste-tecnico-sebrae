**Chalenged-Sebrae** is a full-stack project divided between frontend and backend, developed as part of a technical challenge.

Frontend
The frontend is built using Razor, with support from CSS, JavaScript, and Bootstrap to create a modern, responsive, and intuitive user interface.

Backend
The backend is an API developed in C# 5, following the n-tier architecture and implementing the Repository Pattern. Additionally, the backend includes unit tests to ensure code reliability. The main features include:

Account CRUD: Complete management of create, read, update, and delete operations for accounts.
CEP Lookup: A dedicated endpoint for postal code lookup using the Correios API.
The backend is designed to communicate directly with the frontend, ensuring efficient integration between both parts of the application.



### Getting started
1. Clone the project using the command: **`git clone https://github.com/EmanuelFilipe/teste-tecnico-sebrae.git`**
2. You need to configure VS to load multiple projects when starting the system, loading both the frontend and API projects.
3. Right-click on the Solution  **`"ConsultaCep-SEBRAE"`**, and select  **`"Configure Startup Projects"`**.
4. Choose the option **`"Multiple Startup Projects"`**, and check the **`"Start"`** option for the projects: **`"ConsultaCep.API e ConsultaCep.Web"`**. They should be in this order.
5. Start the application.

<hr />

**Chalenged-Sebrae**  é um projeto full-stack dividido entre frontend e backend, desenvolvido como parte de um desafio técnico.

### Frontend
O frontend é construído utilizando Razor, com suporte de CSS, JavaScript, e Bootstrap.

### Backend
O backend é uma API desenvolvida em C# 6, seguindo a arquitetura n-tier e implementando o Repository Pattern. Além disso, o backend inclui testes unitários para garantir a confiabilidade do código. As principais funcionalidades incluem:

CRUD de Conta: Gerenciamento completo das operações de criar, ler, atualizar e deletar contas.
Consulta de CEP: Um endpoint dedicado para a consulta de CEP utilizando a API dos Correios.
O backend é projetado para se comunicar diretamente com o frontend, garantindo uma integração eficiente entre as duas partes da aplicação.

### Getting started
1. clone o projeto com o comando: **`git clone https://github.com/EmanuelFilipe/teste-tecnico-sebrae.git`**
2. Você deve configurar para o VS carregar multiplos projetos ao iniciar o sistema, carregando o projeto frontend e a api
3. Botão direito do mouse na Solution **`"ConsultaCep-SEBRAE"`**, clique em **`"Configure Startup Projects"`**
4. Selecione a opção **`"Multiple Startup Projects"`**, Marque a opção **`"Start"`** para os projetos: **`"ConsultaCep.API e ConsultaCep.Web"`**. Eles devem estar nessa ordem.
6. Inicie a aplicação


