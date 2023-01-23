import styles from "../styles/Home.module.css";
import Card from "react-bootstrap/Card";
import Slider from "react-slick";
import { DateTime } from "luxon";

export default function VisualizarPet(props) {
  // const tutorId = props.tutorId;

  // console.log(tutorId);

  const borderStyle = {
    border: props.border || "none",
  };

  const listaPets = props.petsLista;

  return (
    <div className={styles.viewCadastroPet} style={borderStyle}>
      {
      listaPets != null ? (
      listaPets.map((pet, i) => {
        return (
          <div>
            <Card border="primary" id={pet.nome}>
              <Card.Header>{pet.nome}</Card.Header>
              <Card.Body>
                <Card.Text>
                  <span style={{ fontWeight: "bold" }}>Animal: </span>
                  {pet.animal}
                  {/* <p><span style={{fontWeight: "bold"}}>Animal: </span>{petCollection[i].animal}</p> */}
                </Card.Text>
                <Card.Text>
                  <span style={{ fontWeight: "bold" }}>Castrado: </span>
                  {pet.castrado ? "Sim" : "Não"}
                </Card.Text>
                <Card.Text>
                  <span style={{ fontWeight: "bold" }}>G&ecirc;nero: </span>
                  {pet.genero == "F" ? "Fêmea" : "Macho"}
                </Card.Text>
                <Card.Text>
                  <span style={{ fontWeight: "bold" }}>
                    Anivers&aacute;rio:{" "}
                  </span>
                  {DateTime.fromISO(pet.nascimento).toFormat("dd/MM/yyyy")}
                </Card.Text>
                <Card.Text>
                  {pet.descricao != null ? (
                    <span>
                      <strong>Descrição:</strong> {pet.descricao}
                    </span>
                  ) : null}
                </Card.Text>
                {/* <Card.Text>
                  <p>
                    <span style={{ fontWeight: "bold" }}>Castrado: </span>
                    {petCollection[i].castrado ? "Sim" : "Não"}
                  </p>
                  <p>
                    <span style={{ fontWeight: "bold" }}>G&ecirc;nero: </span>
                    {petCollection[i].genero}
                  </p>
                  <p>
                    <span style={{ fontWeight: "bold" }}>
                      Anivers&aacute;rio:{" "}
                    </span>
                    {petCollection[i].aniversario}
                  </p>
                  <p>
                    <span style={{ fontWeight: "bold" }}>
                      Descri&ccedil;&atilde;o:{" "}
                    </span>
                    {petCollection[i].descricao}
                  </p>
                </Card.Text> */}
              </Card.Body>
            </Card>
          </div>
        );
      }) ) : (null)}
    </div>
  );
}
