import { useEffect, useState } from "react";
import {useRouter} from "next/router";
import styles from "../../styles/Home.module.css";
import RegistrarPet from "../../components/registrarPet";
import VisualizarPet from "../../components/visualizarPets";

export default function cadastroPet(props) {

    const router = useRouter()
    // console.log(router.query)

    return (

        <div className={styles.mainCadastroPet}>

            <div className={styles.menuCadastroPet}>

                <RegistrarPet tutorId={router.query.id}/>
                 
                <VisualizarPet tutorId={router.query.id}/>
                
            </div>
        </div>

    );
}