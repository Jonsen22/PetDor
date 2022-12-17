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

SLA (latência, vazão, concorrência)
SLA1: 
Latencia: 23.41ms
Vazão: 600
Concorrência: 20

SLA2: 
Latencia: 56.45ms
vazão: 2936
Concorrência: 100

SLA3: 
Latencia: 288.82ms
vazão: 13269
Concorrência: 500

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

Data de Medição: 14/12/2022

Descrição das Configurações: Rodando local em um computador com 16GB de memória

SLA (latência, vazão, concorrência)
SLA1: 
Latencia: 18.78ms
Vazão: 600
Concorrência: 20

SLA2: 
Latencia: 56.45ms
vazão: 2902
Concorrência: 100

SLA3: 
Latencia: 329.34ms
vazão: 12928
Concorrência: 500

Potenciais Gargalos do Sistema: A máquina aceita no máximo 1000 processos simultâneos

![Gráficos](https://i.imgur.com/7vNXTKf.png)

