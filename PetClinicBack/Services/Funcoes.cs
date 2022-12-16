namespace PetDoor.Services
{
    public class Funcoes
    {
        public static string ValidarCpf(string cpf)
        {
            //int cpfNum = int.Parse(cpf);
            int[] numerosCpf = new int[11];
            int index = 0;
            foreach(char c in cpf)
            {
                numerosCpf[index] = int.Parse(c.ToString());
                index++;
            }
            // validação primeiro digito 
            int primeiroDigito = ((numerosCpf[0] * 10 + numerosCpf[1] * 9 +
                numerosCpf[2] * 8 + numerosCpf[3] * 7 + numerosCpf[4] * 6
                + numerosCpf[5] * 5 + numerosCpf[6] * 4 + numerosCpf[7] * 3 +
                numerosCpf[8] * 2) * 10 ) % 11;

            if(primeiroDigito == 10)
                primeiroDigito = 0;

            if(primeiroDigito != numerosCpf[9])
                return "CPF inválido";

            // validação segundo digito 
            int segundoDigito = ((numerosCpf[0] * 11 + numerosCpf[1] * 10 +
                numerosCpf[2] * 9 + numerosCpf[3] * 8 + numerosCpf[4] * 7
                + numerosCpf[5] * 6 + numerosCpf[6] * 5 + numerosCpf[7] * 4 +
                numerosCpf[8] * 3 + numerosCpf[9] * 2) * 10 ) % 11;

            if (segundoDigito == 10)
                segundoDigito = 0;

            if (segundoDigito != numerosCpf[10])
                return "CPF inválido";

            return "CPF válido";
        }
    }
}
