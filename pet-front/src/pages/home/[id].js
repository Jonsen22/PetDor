import VisualizarPet from "../../components/visualizarPets";
import VisualizarConsultas from "../../components/visualizarConsultas";
import { useRouter } from "next/router";
import { useEffect, useState } from "react";
import {
  getConsultasByTutorId,
  getTutorById,
  deleteConsulta,
} from "../../Context/Data";
import styles from "../../styles/Home.module.css";

export default function home(props) {
  const [consultas, setConsultas] = useState([]);
  const [tutor, setTutor] = useState({});
  const [pets, setPets] = useState([])
  const router = useRouter();
  let tutorId = null;

  const deslogar = () => {
    router.push("/");
  };

  const marcarConsulta = (e) => {
    router.push({
      pathname: "/home/marcarConsulta/[id]",
      query: { id: tutorId },
    });
  };

  const adicionarPet = (e) => {
    router.push({
      pathname: "/home/cadastrarPet/[id]",
      query: { id: tutorId },
    });
  };

  const getTutorId = async () => {
    tutorId = router.query.id;
  };

  const getConsultas = async () => {
    let TutorRes = await getTutorById(tutorId);
    setTutor(TutorRes);
    console.log(TutorRes);
    let ConsultaRes = await getConsultasByTutorId(tutorId);
    const listaConsultas = [];

    if (ConsultaRes != undefined) {
      ConsultaRes.forEach((element) => {
        listaConsultas.push(element);
      });
    }

    const listPets = [];
    if (TutorRes != undefined) {
      TutorRes.pets.forEach((element) => {
        listPets.push(element);
      });
    }
    setPets(listPets)
    console.log(listPets)
    setConsultas(listaConsultas);
  };

  getTutorId();

  useEffect(() => {
    if (tutorId != null) {
      getConsultas();
    }

    // getConsultas(tutor);
  }, [tutorId]);

  return (
    <div className={styles.containerHome}>
      <div className={styles.menuHome}>
        <div className={styles.navbarHome}>
          {tutor != undefined ? (
            <span> Bem vindo, {tutor.nome}!</span>
          ) : (
            <span>Bem vindo!</span>
          )}
          {console.log(tutor)}
          <button className={styles.buttonLogout} onClick={() => deslogar()}>
            sair
          </button>
        </div>
        <div className={styles.menusHomePage}>
          <div className={styles.consultasMenu}>
            <div className={styles.submenuConsulta}>
              <span style={{ marginLeft: "15px" }}>Consultas</span>
              <button
                className={styles.buttonLogin}
                style={{ marginRight: "5px" }}
                onClick={(e) => marcarConsulta()}
              >
                Marcar consulta
              </button>
            </div>
            {console.log(consultas)}
            {/* {  console.log(consultas.length)} */}
            {consultas.length > 0 ? (
              <VisualizarConsultas ArrayConsultas={consultas} />
            ) : (
              <div
                style={{
                  height: "100%",
                  justifyContent: "center",
                  alignItems: "center",
                }}
              >
                <span>Não existem consultas</span>
              </div>
            )}
          </div>
          <div className={styles.petsMenu}>
            <div className={styles.submenuPets}>
              <span style={{ marginLeft: "15px" }}>Seus Pets</span>
              <button
                className={styles.buttonLogin}
                style={{ marginRight: "15px" }}
                onClick={(e) => adicionarPet()}
              >
                +
              </button>
            </div>
            <VisualizarPet petsLista={pets} style={{ border: "5px solid green" }} />
            <div></div>
          </div>
        </div>
      </div>
    </div>
  );
}
