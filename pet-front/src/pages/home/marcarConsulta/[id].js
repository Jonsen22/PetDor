import Link from "next/link";
import { useState, useEffect } from "react";
import { useRouter } from "next/router";
import styles from "../../../styles/Home.module.css";
import Select from "react-select";
import { getTutorById, getAllAgendas, postConsulta } from "../../../Context/Data";

export default function Cadastro(props) {
  const router = useRouter();
  const [tutor, setTutor] = useState({});
  const [agendaOpcoes, setAgendaOpcoes] = useState([]);
  const [pets, setPets] = useState([]);
  const [petCampo, setPetCampo] = useState("");
  const [vetCampo, setVetCampo] = useState("");
  const [data, setData] = useState("");
  const [descricao, setDescricao] = useState("");
  const duracao = 30;
  const custo = 150;
  const presente = "Y";
  let tutorId = null;

  const getTutorId = async () => {
    tutorId = router.query.id;
  };

  getTutorId();

  const getPets = async () => {
    let TutorRes = await getTutorById(tutorId);
    setTutor(TutorRes);
    const listaPets = [];
    if (TutorRes != undefined) {
        TutorRes.pets.forEach((element) => {
        let opcao = { label: element.nome, value: element.petId };
        listaPets.push(opcao);
      });
    }
    setPets(listaPets);
    let agendaRes = await getAllAgendas();
    // console.log(agendaRes)

    const listaVetsAgenda = [];
    if (agendaRes != undefined) {
      agendaRes.forEach((element) => {
        let opcao = {
          label: element.veterinario.nome,
          value: element.agendaId,
        };
        listaVetsAgenda.push(opcao);
      });
    }
    setAgendaOpcoes(listaVetsAgenda);
  };

  function isAfterCurrentTime(datetime) {
    var inputTime = new Date(datetime);
    var currentTime = new Date();
    if (!(inputTime.getTime() > currentTime.getTime())) {
      alert("Não é possível marca consulta para tempo passado");
      setData("");
      return;
    }

    setData(datetime);
  }

  useEffect(() => {
    getPets();
  }, [tutorId]);
  //   const [cadastroConcluido, setCadastroConcluido] = useState(false)

  const voltar = () => {
    router.push({
      pathname: "/home/[id]",
      query: { id: router.query.id },
    });
  };

  const handleSubmit = async () => {
    const response = await postConsulta (
        descricao,
        presente,
        custo,
        data,
        duracao,
        petCampo,
        vetCampo,
    );

    console.log(response)


    if (response.status != 201) return; //criar mensagem de erro

    alert("Consulta Agendada!");
    voltar();
  };

  return (
    <div className={styles.containerLogin}>
      <div className={styles.cadastro} style={{ height: "70%", width: "40%" }}>
        <div className={styles.titulo}>
          <span> Agendar Consulta</span>
        </div>
        <div className={styles.usuario}>
          <span style={{ margin: "0 0 2px 0" }}>Pet:</span>
          {console.log(pets)}
          <Select
            styles={{
              control: (baseStyles, state) => ({
                ...baseStyles,
                // padding: "0.1rem",
                height: "31px",
                margin: "0.3rem 0 0 5px",
                background: "#d3d3d3",
                borderRadius: "10px",
                width: "200px",
              }),
            }}
            placeholder="Seus Pets"
            options={pets}
            onChange={(opt) => {
              setPetCampo(opt.value);
            }}
          />
          <span style={{ margin: "5px 0 2px 0" }}>Veterinário:</span>
          <Select
            styles={{
              control: (baseStyles, state) => ({
                ...baseStyles,
                // padding: "0.1rem",
                height: "31px",
                margin: "0.3rem 0 0 5px",
                background: "#d3d3d3",
                borderRadius: "10px",
                width: "200px",
              }),
            }}
            placeholder="Veterinários"
            options={agendaOpcoes}
            onChange={(opt) => {
              setVetCampo(opt.value);
            }}
          />

          <span style={{ margin: "5px 0 2px 0" }}>Data:</span>
          <input
            className={styles.inputLogin}
            type="datetime-local"
            value={data}
            onChange={(e) => {
              isAfterCurrentTime(e.target.value);
            }}
          />

          <span style={{ margin: "5px 0 2px 0" }}>Descrição:</span>
          <textarea
            className={styles.textAreaDescricao}
            type="textarea"
            value={descricao}
            style={{ height: "200px", width: "200px" }}
            onChange={(e) => {
              setDescricao(e.target.value);
            }}
          ></textarea>

          <button
            className={styles.buttonLogin}
            style={{ margin: "30px 0 0 0", width: "100px" }}
            onClick={() => handleSubmit()}
          >
            Agendar
          </button>
        </div>
        <div
          style={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
          }}
        >
          <button
            onClick={(e) => voltar()}
            className={styles.buttonLogin}
            style={{ margin: "20px 0 0 0", background: "green" }}
          >
            voltar
          </button>
        </div>
      </div>
    </div>
  );
}
