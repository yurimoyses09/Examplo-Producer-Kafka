# Examplo-Producer-Kafka
Exemplo de projeto producer para popular um topico do kafka

# Primieros passos
. Criar conta no Confluent Cloud, lá é possivel criar os topicos, clusters etc (link https://login.confluent.io)

. Depois de criar a sua conta é possivel seguir essa documentação que explica o passo a passo do que necessario fazer antes mesmo de executar o producer (link https://developer.confluent.io/get-started/dotnet/#introduction)

# Executar Producer
. Para executar o producer é necessario configurar o producer com os seguntes valores e campos (Campos se encontram no appsettings.json)
   
   "NomeTopicoKafka": "Nome do topico criado
   
   "ServerBoostrap": "Link do servidor Boostrap"
   
   "ClientId": "Nome do CliendId"
   
   "ApiKeyUsuario": "Usuario do apikey criado"
   
   "ApiKeySenha": "Senha do apikey criado"
   
   "LocationCertificatePem": "Diretorio do arquivo de certificado .pem"

. Após essa configuração você pode rodar a api do projeto


# Executando Producer
. Essa é a tela do swagger para podermos utlizar endpoint criado (https://localhost:5001/api/ControllerProducer)
  
![image](https://user-images.githubusercontent.com/53382267/149677866-06b89e75-44d5-414c-969d-d8ffdd193d29.png)

. Esses são os dados que serão enviados ate o topico criado anteriormente
  
![image](https://user-images.githubusercontent.com/53382267/149677951-3c3830bc-5c4e-4abe-98c3-46f76fd7289b.png)

. Se tudo estiver dado certo, no Confluent Cloud sera possivel ver os dados enviados

![image](https://user-images.githubusercontent.com/53382267/149678036-ea7f6495-1273-4d88-a520-17ede5aa0c4c.png)

