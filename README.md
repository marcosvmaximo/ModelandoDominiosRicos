
# ModelandoDominiosRicos 🚀
Essa API foi desenvolvida para um sistema de pedidos utilizado em lojas em geral, que engloba clientes, descontos, pedidos e outras funcionalidades. O objetivo principal desse desenvolvimento é praticar o uso de conceitos importantes no desenvolvimento de software, como Domain Driven Design (DDD), CQRS (Command Query Responsibility Segregation) e testes unitários para o domínio da aplicação. 

Além disso, a API foi criada com uma abordagem orientada a objetos, permitindo uma maior flexibilidade e facilidade no desenvolvimento e manutenção do código. Com isso, espera-se que a API seja uma solução robusta e escalável para o gerenciamento de pedidos de lojas em geral.
## Referência

Fiz uso de diversos artigos de patterns, conceitos e demais itens de estudos, aqui estaram listados alguns deles:

 - [Article MediatR](https://henriquemauri.net/mediatr-no-net-6-0/)
  - [Medium DDD no código](https://medium.com/cwi-software/domain-driven-design-do-in%C3%ADcio-ao-c%C3%B3digo-569b23cb3d47)

## Funcionalidades

- Cadastro de Clientes
- Envio de Email 
- Autenticação ao login dos Clientes
- Criação de Pedidos
- Processamento de Pedidos
- Integração com API's (Cep, Email)


## Aprendizados

Neste projeto, pude aplicar os conceitos que aprendi em Orientação a Objetos, criando classes coesas que representam o CORE do negócio (Uso também de DDD), classes essas que estão "fechadas" (Uso também do Solid) para apenas sua responsabilidades. Além disso, pude definir contratos e usar herança e polimorfismo para reutilizar código.

Com relação à segregação de responsabilidades, busquei dividir as tarefas de forma clara e coesa, garantindo que cada componente do projeto tivesse uma responsabilidade bem definida.

Quanto aos padrões de projeto, aprendi sobre o CQRS e pude aplicá-lo de forma eficiente em minha arquitetura. Com o uso do MediatR, consegui separar a lógica de gravação no banco de dados da realização de buscas, e utilizei filas de comandos e eventos para garantir que o projeto fosse escalável e pudesse lidar com um grande volume de dados.

Também busquei garantir que o código fosse semântico e representasse de forma clara as funcionalidades do projeto, fazendo uso de nomes significativos para classes e métodos. Com isso, consegui criar uma aplicação mais legível e fácil de manter.
