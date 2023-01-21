import Head from 'next/head'
import Image from 'next/image'
import Link from 'next/link'
import styles from '../styles/Home.module.css'
import { login } from "../Context/Data";
import { useState } from 'react';
import {useRouter} from "next/router";

export default function Home() {

  const [email, setEmail] = useState("");
  const [senha, setSenha] = useState("");

  const router = useRouter();

  const handleLogin = async () => {

    const res = await login(email, senha);
    
    // console.log("Response :: ", res.data);
    
    if (res.status != 200) {
      alert("Erro no Login, verifique seu login.")
    } else {
      router.push({
        pathname: '/home',
      });
    }
  };

  return (
    <div className={styles.containerLogin}>
      <div className={styles.login}>
        <div className={styles.titulo}>
          <span> PetD'or</span>
        </div>
        <div className={styles.usuario}>
          <span style={{margin:"0 0 5px 0"}}>Email:</span>
          <input className={styles.inputLogin} onChange={(e) => setEmail(e.target.value)}></input>
          <span style={{margin:"5px 0 5px 0"}}>Senha:</span>
          <input className={styles.inputLogin} type="password" onChange={(e) => setSenha(e.target.value)}></input>
          <button className={styles.buttonLogin} style={{margin:"20px 0 0 0"}}  onClick={() => handleLogin()}>Entrar</button>
        </div>
        <div className={styles.LinkCadastro}>
        <span>Ainda não possui uma conta? </span>
          <Link style={{ color: "#0070f3"}}  href="/cadastro">Cadastre-se aqui</Link>
        </div>
      </div>
    </div>
  )
}
