import { useState } from "react";
import styles from "../styles/Home.module.css";
import Select from "react-select";
import { useRouter } from "next/router";

export default function registrarPet(props) {
  const [nome, setNome] = useState("");
  const [genero, setGenero] = useState("");
  const [aniversario, setAniversario] = useState("");
  const [castrado, setCastrado] = useState("");
  const [animal, setAnimal] = useState("");
  const [raca, setRaca] = useState("");
  const [descricao, setDescricao] = useState("");
  const tutorId = props.tutorId;

  console.log(tutorId);

  const router = useRouter();

  const voltar = () => {
    router.push({
      pathname: '/home/[id]',
      query: {id: tutorId}
    });
  }

  const generos = [
    { label: "Masculino", value: "M" },
    { label: "Feminino", value: "F" },
  ];

  const castrados = [
    { label: "Sim", value: "true" },
    { label: "Não", value: "false" },
  ];

  return (
    <div className={styles.formCadastroPet}>
      <div>
        <span>Cadastrar Pet</span>
      </div>
      <div className={styles.inputsCadastroPet}>
        <span style={{ margin: "0 0 2px 0" }}>Nome:</span>
        <input
          className={styles.inputLogin}
          value={nome}
          onChange={(e) => {
            setNome(e.target.value);
          }}
        />
        <span style={{ margin: "5px 0 2px 0" }}>Gênero:</span>

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

        <span style={{ margin: "5px 0 2px 0" }}>Data de nascimento:</span>
        <input
          className={styles.inputLogin}
          type="date"
          value={aniversario}
          onChange={(e) => {
            setAniversario(e.target.value);
          }}
        />
        <span style={{ margin: "5px 0 2px 0" }}>Castrado:</span>
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
          placeholder="Castrado"
          options={castrados}
          onChange={(opt) => {
            setCastrado(opt.value);
          }}
        />
        <span style={{ margin: "5px 0 2px 0" }}>Animal:</span>
        <input
          className={styles.inputLogin}
          value={animal}
          onChange={(e) => {
            setAnimal(e.target.value);
          }}
        />

        <span style={{ margin: "5px 0 2px 0" }}>Raça:</span>
        <input
          className={styles.inputLogin}
          value={raca}
          onChange={(e) => {
            setraca(e.target.value);
          }}
        />
        <span style={{ margin: "5px 0 2px 0" }}>Descrição:</span>
        <input
          className={styles.inputLogin}
          value={descricao}
          onChange={(x) => {
            setDescricao(x.target.value);
          }}
        />
      </div>
      <div>
        <button className={styles.buttonLogin} style={{ margin: "20px 0 0 0" }}>
          Registrar
        </button>
        {props.voltar ? (
          <button
          onClick={(e) => voltar()}
            className={styles.buttonLogin}
            style={{ margin: "20px 0 0 20px", background:"green" }}
          >
            voltar
          </button>
        ) : null}
      </div>
    </div>
  );
}
