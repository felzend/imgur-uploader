## Tutorial de utilizacao da aplicacao

Essa aplicacao tem por objetivo facilitar o upload de imagens no site imgur, automatizando a obtencao dos links dessas imagens e possibilitando formatar esses links no padrao bbcode (utilizadas em foruns vbulletin e outros).

## Download

Faca o download a partir do link: _ _

Extraia todos os arquivos para uma nova pasta.

A seguir, serao mostrados os passos necessarios para utilizar a aplicacao.

### Criar uma conta no Imgur

Caso nao tenha uma conta no site, sera necessario que crie no seguinte link: _https://imgur.com/register?redirect=%2F_.

Preencha todos os campos e selecione **Next**. Caso contrario, selecione **Sign In** e faca login em sua conta, conforme a imagem a seguir. Tambem e' possivel se registrar utilizando Facebook, Twitter, Google ou Yahoo!.

<img src="https://i.imgur.com/nbc6afN.png" width="500"/>

### Configurar Aplicacao

Apos realizar login em sua conta, selecione **Settings** (na imagem do canto superior direito), conforme a imagem a seguir.

<img src="https://i.imgur.com/ghWGlb9.png" width="200"/>

Em seguida, selecione **Applications** (ou entre no link _https://api.imgur.com/oauth2/addclient_), conforme a imagem a seguir. Preencha somente os seguintes campos:

* Em **Application Type**, coloque algum nome de sua escolha para identificar o motivo da utilizacao do site imgur
* Em **Authorization Type**, deixe a segunda opcao marcada
* Em **Email**, preencha seu email
* Em **Description**, coloque uma descricao qualquer
* Clique em **Submit**

<img src="https://i.imgur.com/cCcMyJX.png" width="600"/>

Guarde os campos **Client ID** e **Client Secret** (sao chaves de utilizacao pessoal) gerados, entre na pasta **Config** da aplicacao, crie o arquivo _appsettings.json_ e insira o seguinte os dois campos obtidos anteriormente da seguinte forma (entre aspas):

```json
{
  "client_id": "CLIENT ID",
  "client_secret": "CLIENT SECRET"
}
```

Apos isso, a aplicacao esta pronta para utilizacao.
