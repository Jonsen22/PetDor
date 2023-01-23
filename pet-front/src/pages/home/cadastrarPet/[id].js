import { useEffect, useState } from "react";
import {useRouter} from "next/router";
import styles from "../../../styles/Home.module.css";
import RegistrarPet from "../../../components/registrarPet";

export default function cadastrarPet(props) {

    const router = useRouter()
    console.log(router.query.id)

    return (

        <div className={styles.mainCadastroPet} 
        style={{border:"none"}}
       >

            <div className={styles.menuCadastroPet}
             style={{width: "20%"}}>

                <RegistrarPet tutorId={router.query.id} voltar={true}/>
                 
                
            </div>
        </div>

    );
}