Resultados Obtidos:
	Os resultados dos testes que foram realizados foram obtidos por meio da execução dos testes. Para efetuar tal tarefa, foi utilizada a ferramenta “K6” para as medições do SLA.

-------------------------------------------------------------------------------------------------------------------------------------------------------

Serviço 1:

Serviço: Get Tutor

Tipo de Operação: Inserção

Arquivos Envolvidos:	PetDoor/PetClinicBack/Startup.cs
			PetDoor/PetClinicBack/Models/Tutor.cs   
			PetDoor/PetClinicBack/Controllers/TutorController.cs


Arquivos com o código fonte de medição do SLA:	PetDoor/Teste de Carga - k6/index.js 
 						PetDoor/Teste de Carga - k6/scenarios/GetTutor.js 

Data de Medição: 14/12/2022
Descrição das Configurações: Rodando local em um computador com 16GB de memória

SLA1: <br />
Latencia: 23.41ms <br />
Vazão: 600 <br />
Concorrência: 20 <br />

SLA2:  <br />
Latencia: 56.45ms <br />
vazão: 2936 <br />
Concorrência: 100 <br />

SLA3:  <br />
Latencia: 288.82ms <br />
vazão: 13269 <br />
Concorrência: 500 <br />

Potenciais Gargalos do Sistema: A máquina aceita no máximo 1000 processos simultâneos

-------------------------------------------------------------------------------------------------------------------------------------------------------

Serviço 2:

Serviço Post Pet

Tipo de Operação: Inserção

Arquivos Envolvidos:	PetDoor/PetClinicBack/Startup.cs
			PetDoor/PetClinicBack/Models/Pet.cs   
			PetDoor/PetClinicBack/Controllers/PetsController.cs
			
Arquivos com o código fonte de medição do SLA:	PetDoor/Teste de Carga - k6/index.js 
						PetDoor/Teste de Carga - k6/scenarios/PostPet.js

Data de Medição: 19/01/2022

Descrição das Configurações: Rodando local em um computador com 16GB de memória

SLA1:  <br />
Latencia: 18.78ms <br />
Vazão: 600 <br />
Concorrência: 20 <br />

SLA2: <br />
Latencia: 56.45ms <br />
vazão: 2902 <br />
Concorrência: 100 <br />

SLA3:  <br />
Latencia: 329.34ms <br />
vazão: 12928 <br />
Concorrência: 500 <br />

Potenciais Gargalos do Sistema: A máquina aceita no máximo 1000 processos simultâneos

![Gráficos](https://i.imgur.com/7vNXTKf.png)

2ª Medição

Serviço 1:

Serviço: Get Tutor

Tipo de Operação: Inserção

Arquivos Envolvidos:	PetDoor/PetClinicBack/Startup.cs
			PetDoor/PetClinicBack/Models/Tutor.cs   
			PetDoor/PetClinicBack/Controllers/TutorController.cs


Arquivos com o código fonte de medição do SLA:	PetDoor/Teste de Carga - k6/index.js 
 						PetDoor/Teste de Carga - k6/scenarios/GetTutor.js 

Data de Medição: 14/12/2022
Descrição das Configurações: Rodando local em um computador com 16GB de memória

SLA1: <br />
Latencia: 19.27ms <br />
Vazão: 600 <br />
Concorrência: 20 <br />

SLA2:  <br />
Latencia: 28.73ms <br />
vazão: 3000 <br />
Concorrência: 100 <br />

SLA3:  <br />
Latencia: 34.95ms <br />
vazão: 14758 <br />
Concorrência: 500 <br />

Potenciais Gargalos do Sistema: A máquina aceita no máximo 1000 processos simultâneos

-------------------------------------------------------------------------------------------------------------------------------------------------------

Serviço 2:

Serviço Post Pet

Tipo de Operação: Inserção

Arquivos Envolvidos:	PetDoor/PetClinicBack/Startup.cs
			PetDoor/PetClinicBack/Models/Pet.cs   
			PetDoor/PetClinicBack/Controllers/PetsController.cs
			
Arquivos com o código fonte de medição do SLA:	PetDoor/Teste de Carga - k6/index.js 
						PetDoor/Teste de Carga - k6/scenarios/PostPet.js

Data de Medição: 19/01/2022

Descrição das Configurações: Rodando local em um computador com 16GB de memória

SLA1:  <br />
Latencia: 16.99ms <br />
Vazão: 600 <br />
Concorrência: 20 <br />

SLA2: <br />
Latencia: 23.78ms <br />
vazão: 3000 <br />
Concorrência: 100 <br />

SLA3:  <br />
Latencia: 25.71ms <br />
vazão: 14790 <br />
Concorrência: 500 <br />

Potenciais Gargalos do Sistema: A máquina aceita no máximo 1000 processos simultâneos

![Gráficos](https://i.imgur.com/BfuHvrq.png)
