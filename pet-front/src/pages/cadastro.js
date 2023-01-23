import Link from "next/link";
import { useState } from "react";
import { useRouter } from "next/router";
import styles from "../styles/Home.module.css";
import { postTutor, postUser } from "../Context/Data";
import Select from "react-select";

const generos = [
  { label: "Masculino", value: "M" },
  { label: "Feminino", value: "F" },
];

export default function Cadastro(props) {
  const router = useRouter();
  const [nome, setNome] = useState("");
  const [genero, setGenero] = useState("");
  const [aniversario, setAniversario] = useState("");
  const [email, setEmail] = useState("");
  const [cpf, setCpf] = useState("");
  const [celular, setCelular] = useState("");
  const [cep, setCep] = useState("");
  const [senha, setSenha] = useState("");
  //   const [cadastroConcluido, setCadastroConcluido] = useState(false)

  const handleSubmit = async () => {
    await postTutor(
      nome,
      genero.charAt(0),
      aniversario,
      email,
      cpf,
      celular,
      cep
    ).then(async (response) => {
      console.log(response);

      if (response.status != 201) return; //criar mensagem de erro

      console.log(response.data.tutorId);
      let id = response.data.tutorId;
      if (id != undefined) {
        if (id < 10) {
          id = "0" + response.data.tutorId.toString();
          console.log(id);
        } else id = response.data.tutorId.toString();
      }

      console.log(id);
      const responseUser = await postUser(email, senha, id);

      if (responseUser.status != 200) return;

      router.push({
        pathname: "/cadastroPet/[id]",
        query: { id: response.data.tutorId },
      });
      console.log(responseUser);
    });
  };

  return (
    <div className={styles.containerLogin}>
      <div className={styles.cadastro}>
        <div className={styles.titulo}>
          <span> PetD'or</span>
        </div>
        <div className={styles.usuario}>
          <span style={{ margin: "0 0 2px 0" }}>Nome:</span>
          <input
            className={styles.inputLogin}
            value={nome}
            onChange={(e) => {
              setNome(e.target.value);
            }}
          />
          <span style={{ margin: "5px 0 2px 0" }}>Email:</span>
          <input
            className={styles.inputLogin}
            value={email}
            onChange={(e) => {
              setEmail(e.target.value);
            }}
          />
          <span style={{ margin: "5px 0 2px 0" }}>Senha:</span>
          <input
            className={styles.inputLogin}
            type="password"
            value={senha}
            onChange={(e) => {
              setSenha(e.target.value);
            }}
          />
          <span style={{ margin: "5px 0 2px 0" }}>Data de nascimento:</span>
          <input
            className={styles.inputLogin}
            type="date"
            value={aniversario}
            onChange={(e) => {
              setAniversario(e.target.value);
            }}
          />
          <span style={{ margin: "5px 0 2px 0" }}>Gênero:</span>
          {/* <input
            className={styles.inputLogin}
            value={genero}
            onChange={(e) => {
              setGenero(e.target.value);
            }}
          /> */}
          <Select
            styles={{
              control: (baseStyles, state) => ({
                ...baseStyles,
                // padding: "0.1rem",
                height: "31px",
                margin: "0.3rem 0 0 5px",
                background: "#d3d3d3",
                borderRadius: "10px",
                width: "185px",
              }),
            }}
            placeholder="Gênero"
            options={generos}
            onChange={(opt) => {
              setGenero(opt.value);
            }}
          />
          <span style={{ margin: "5px 0 2px 0" }}>Celular:</span>
          <input
            className={styles.inputLogin}
            value={celular}
            type="number"
            onChange={(e) => {
              setCelular(e.target.value);
            }}
          />
          <span style={{ margin: "5px 0 2px 0" }}>CPF:</span>
          <input
            className={styles.inputLogin}
            value={cpf}
            type="number"
            onChange={(x) => {
              setCpf(x.target.value);
            }}
          />
          <span style={{ margin: "5px 0 2px 0" }}>CEP:</span>
          <input
            className={styles.inputLogin}
            value={cep}
            type="number"
            onChange={(e) => {
              setCep(e.target.value);
            }}
          />
          <button
            className={styles.buttonLogin}
            style={{ margin: "20px 0 0 0" }}
            onClick={() => handleSubmit()}
          >
            Cadastrar
          </button>
        </div>
        <div className={styles.LinkLogin}>
          <span>Já possui uma conta? </span>
          <Link style={{ color: "#0070f3" }} href="/">
            Entre aqui
          </Link>
        </div>
      </div>
    </div>
  );
}
