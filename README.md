
# 📋 Informações do Projeto

Projeto desenvolvido em C# .NET implementando um Windows Service (Worker Service) do qual realiza uma verificação da situação de dispositivos a cada X segundos emitindo Logs no terminal e em Logs, informando o IP, Nome do Dispositivo e seu status.

# ⚙️Instruções de Execução 
Para o funcionamento do projeto, primeiramente é necessário ter instalado o seguinte:

-NET 8.0

-Microsoft Visual Studio

A partir disso, é possível baixar e instalar os arquivos:

```bash
git clone https://github.com/Jackoki/MonitorDevicesService.git
cd MonitorDevicesService
dotnet restore
dotnet run
```

Uma outra possibilidade é utilizar o Visual Studio e realizar a clonagem e execução do serviço pela própria IDE

Passo 1: Abra o Visual Studio
<img width="1775" height="838" alt="image" src="https://github.com/user-attachments/assets/5bfcf682-5694-43af-9bbd-17dcd8573c51" />

Passo 2: Cole o link do repositório https://github.com/Jackoki/MonitorDevicesService.git e clique em clonar
<img width="742" height="426" alt="image" src="https://github.com/user-attachments/assets/09c8932a-a9b2-4a4a-b983-48b751cd3100" />

Passo 3: Execute o projeto com a tecla "F5"
<img width="2368" height="826" alt="image" src="https://github.com/user-attachments/assets/a8d42725-64e3-47f1-85a2-d9fe593d8eb9" />

# ❔ Explicações das Decisões
- Windows Service ou Worker Service: Foi decidido realizar o projeto em Worker Service ao invés de Windows Service devido a sua automatização e facilitação na execução do projeto, já que o mesmo contém diversas propriedades que diminui a complexidade de código, como a questão de Injenção de Dependência, configuração do appsettings.json e facilitação do uso Hosted Services, do qual diminui a execução de serviços de forma manual.
- Separação de Camadas: A estrutura do projeto foi feita a partir de 5 camadas (Worker, Utils, Data, Services, Models) de acordo com as suas responsabilidades para uma manutenção e compreensão de código melhor de acordo com os principios de Clean Code.
- Injeção de Dependências: No arquivo Program.cs é realizado a declaração de informações em singleton para a aplicação de Injeção de Dependências para desacoplamento de classes, limpeza de código e melhor manutenção.
- Dados de Dispositivos: Foi registrado os dispositivos no arquivo appsettings.json para centralizar as informações em um JSON apenas e não aumentar a complexidade em relação a persistência de dados em um banco de dados. Foi escolhido também o uso de JSON ao invés de uma lista para simular os dispositivos como se fosse uma API HTTP.
- Implementação de Logs: Implementação dos logs por meio do ILogger do qual emite os logs tanto no terminal como no arquivo logs.txt na pasta logs de acordo com os requisitos.
- Retry: Utilização do retry por meio do loop While no DeviceStatusService da qual realiza X tentativas que é configurada no arquivo appsettings.json 'MaxRetries'. Como foi utilizado também a condição While no arquivo Worker.cs, ele continuará a fazer o serviço até ele ser cancelado/parado de forma manual.
- Random para Condição: Como foi pedido no requisito, foi utilizado uma simulação de status, do qual realizará a chamada de um número aleatório e caso este seja menor que 30 será simulado como OFFLINE.
- Tratamento de Exceções: Implementação de tratamento de exceções no arquivo DeviceStatusService para que o Worker continuasse rodando caso uma exceção seja lançada.

# 💬 Prompts de IA Perguntados no Projeto (ChatGPT)
[Prompt 1](https://github.com/Jackoki/MonitorDevicesService/blob/master/prompts/Prompt%201.pdf)

[Prompt 2](https://github.com/Jackoki/MonitorDevicesService/blob/master/prompts/Prompt%202.pdf)

[Prompt 3](https://github.com/Jackoki/MonitorDevicesService/blob/master/prompts/Prompt%203.pdf)

[Prompt 4](https://github.com/Jackoki/MonitorDevicesService/blob/master/prompts/Prompt%204.pdf)

[Prompt 5](https://github.com/Jackoki/MonitorDevicesService/blob/master/prompts/Prompt%205.pdf)

[Prompt 6](https://github.com/Jackoki/MonitorDevicesService/blob/master/prompts/Prompt%206.pdf)

[Prompt 7](https://github.com/Jackoki/MonitorDevicesService/blob/master/prompts/Prompt%207.pdf)
