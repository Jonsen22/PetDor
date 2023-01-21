import Head from 'next/head'
import Image from 'next/image'
import Link from 'next/link'
import styles from '../styles/Home.module.css'

export default function Home() {
  return (
    <div className={styles.containerLogin}>
      <div className={styles.login}>
        <div className={styles.titulo}>
          <span> PetD'or</span>
        </div>
        <div className={styles.usuario}>
          <span style={{margin:"0 0 5px 0"}}>Email:</span>
          <input className={styles.inputLogin}></input>
          <span style={{margin:"5px 0 5px 0"}}>Senha:</span>
          <input className={styles.inputLogin} type="password"></input>
          <button className={styles.buttonLogin} style={{margin:"20px 0 0 0"}}>Entrar</button>
        </div>
        <div className={styles.LinkCadastro}>
        <span>Ainda não possui uma conta? </span>
          <Link style={{ color: "#0070f3"}}  href="/cadastro">Cadastre-se aqui</Link>
        </div>
      </div>
    </div>
  )
}
