import styles from "../styles/Home.module.css";
import { deleteConsulta } from "../Context/Data";
import { useEffect, useState } from "react";
import { DateTime } from "luxon";

export default function VisualizarConsultas(props) {
  const consultas = props.ArrayConsultas;
  console.log(consultas);

  //   const consultas = [
  //     {
  //       data: "2301390821",
  //       custo: "32132",
  //       descricao: "dlwadjwa",
  //     },

  //     {
  //       data: "512312",
  //       custo: "36542132",
  //       descricao: "hdfesfs",
  //     },
  //   ];

  function isAfterCurrentTime(datetime) {
    var inputTime =  DateTime.fromISO(datetime);
    var currentTime =  DateTime.now();

    console.log(inputTime.diffNow().as("hours") );
    if ((inputTime.diffNow().as("hours")) < 12) {
      alert("Não é possivel cancelar uma consulta com menos de 12H");
      return false;
    }
    return true;
  }

  const handleDeleterConsulta = async (consulta) => {
    console.log(consulta)
    if(isAfterCurrentTime(consulta.data)) {
      let deleteRes = await deleteConsulta(consulta.consultaId);
      console.log(deleteRes);
      window.location.reload(false);
    }

    // 
  };

  function getTime(datetime) {
    return datetime.substring(11, 16);
  }

  function ChangeDateFormat(datetime) {
    return (
      datetime.substring(8, 10) +
      "-" +
      datetime.substring(5, 7) +
      "-" +
      datetime.substring(0, 4)
    );
  }

  return (
    <div className={styles.viewConsultas}>
      {consultas.map((c) => {
        return (
          <div className={styles.cardConsultas}>
            <div className={styles.titulocardConsultas}>
              <span style={{ textAlign: "center" }}>
                <strong>Pet:</strong> {c.pet.nome}{" "}
              </span>
            </div>
            <div className={styles.infocardConsultas}>
              <span style={{ padding: "0 10px 0 10px" }}>
                <strong>Data:</strong> {ChangeDateFormat(c.data)}
              </span>
              <span style={{ padding: "0 10px 0 10px" }}>
                <strong>Horario:</strong>
                {getTime(c.data)}
              </span>
              <span style={{ padding: "0 10px 0 10px" }}>
                <strong>Custo:</strong> R${c.custo}
              </span>
              {c.descricao != null ? (
                <span style={{ padding: "0 10px 0 10px", width: "100%" }}>
                  <strong>Descrição:</strong> {c.descricao}
                </span>
              ) : null}
            </div>
            <div
              style={{
                display: "flex",
                justifyContent: "flex-end",
                paddingRight: "5px",
              }}
            >
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="16"
                height="16"
                fill="currentColor"
                class="bi bi-trash"
                viewBox="0 0 16 16"
                color="Red"
                style={{ cursor: "pointer" }}
                onClick={(e) => handleDeleterConsulta(c)}
              >
                <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z" />
                <path
                  fill-rule="evenodd"
                  d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z"
                />
              </svg>
            </div>
          </div>
        );
      })}
    </div>
  );
}
