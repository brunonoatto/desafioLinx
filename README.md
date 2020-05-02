# desafioLinx
Desafio para processo seletivo da Linx

Para realizar o desafio em questão, decidi criar uma classe(DroneCommand) que representa cada comando que o drone irá executar. Após criei uma classe de builder(CommandBuilder) para guardar a regra de negócio de como se monta a lista de comando a partir o input. Por fim, criei a classe Drone que irá solicitar para o builder os comandos a partir do input recebido, utilizar os comandos para setar os pontos cardiais e retorna-los formatado.

Caso o drone tivesse comandos mais complexos e com mais diversidade, eu iria criar uma interface ICommand com um método Execute, e para cada tipo de comando iria implementar uma classe herdando de ICommand. Esses comandos iriam ser criados pelo builder e a classe Drone decidiria o que fazer com cada tipo. Aqui neste casso até poderia pensar em utilizar o Pattern Commands.

Caso fosse necessário retornar, além de (999, 999) no erro, também uma menssagem, iria utilizar alguma classe de Notification, com injeção de dependência do tipo scoped, para levar o erro da classe de builder até a classe de Drone ou Program.
