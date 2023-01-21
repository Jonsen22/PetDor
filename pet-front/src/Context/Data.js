import axios from "axios";

const config = {
    headers: {
        'Access-Control-Allow-Origin': '*',
        'Content-Type': 'application/json',
    }
};

export async function postTutor(nome, genero, aniversario, email, cpf, celular, cep) {
    try {
        const response = await axios.post('https://localhost:5001/api/Tutor', {
            Nome: nome,
            Genero: genero,
            Aniversario: aniversario,
            Email: email,
            CPF: cpf,
            Celular: celular,
            CEP: cep
        }, config );
        console.log(response);
        return response;
    } catch(error) {
        console.log(error);
    }
}

export async function getTutorById(id) {
    try {
        const response = await axios.get(`https://localhost:5001/api/tutor/${id}`)
        console.log(response.data);
        return response.data;
    } catch(error) {
        console.log(error)
    }
}