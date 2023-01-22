import styles from "../styles/Home.module.css";
import { getPetById } from "../Context/Data";
import { useEffect, useState } from "react";

export default function VisualizarConsultas(props) {
    
    const [pet, setPet] = useState({})
    const consulta = props.consulta
    
    
    useEffect( async() => {
        const response = await getPetById(props.PetId)
        setPet(response.data)
    },[])

    return(

        <ul>
            <li>Pet: {pet.Nome} </li>
            <li>Data: {consulta.Data}</li>
            <li>Custo: {consulta.Custo}</li>
            <li>Descrição: {consulta.Descricao}</li>
        </ul>

    )
}