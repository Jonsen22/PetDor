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
        // console.log(response);
        return response;
    } catch(error) {
        console.log(error);
    }
}

export async function postConsulta(descricao, presente, custo, data, duracao, petid, agendaid) {
    try {
        const response = await axios.post('https://localhost:5001/api/consulta/', {
            Descricao: descricao,
            Presente: presente,
            Custo: custo,
            Data: data,
            Duracao: duracao,
            PetId: petid,
            AgendaId: agendaid
        }, config );
        // console.log(response);
        return response;
    } catch(error) {
        console.log(error);
    }
}


export async function getTutorById(id) {
    try {
        const response = await axios.get(`https://localhost:5001/api/tutor/${id}`)
        // console.log(response.data);
        return response.data;
    } catch(error) {
        console.log(error)
    }
}



export async function getPetById(id) {
    try {
        const response = await axios.get(`https://localhost:5001/api/Pets/${id}`)
        // console.log(response.data);
        return response.data;
    } catch(error) {
        console.log(error)
    }
}

export async function getConsultasByTutorId(id) {
    try {
        const response = await axios.get(`https://localhost:5001/api/consulta/consultasTutor/${id}`)
        console.log(response.data);
        return response.data;
    } catch(error) {
        console.log(error)
    }
}

export async function getAllVeterinarios() {

    try {

        const response = await axios.get(`https://localhost:5001/api/veterinario`);
        return response.data;
    } catch (error) {
        console.log("Error :: ", error);
    }

}

export async function getAllAgendas() {

    try {

        const response = await axios.get(`https://localhost:5001/api/agenda`);
        return response.data;
    } catch (error) {
        console.log("Error :: ", error);
    }

}



export async function login(email, senha) {

    try {

        return await axios.post(`https://localhost:5001/api/User/login`, {"email": email, "senha": senha});

    } catch (error) {
        console.log("Error :: ", error);
    }

}