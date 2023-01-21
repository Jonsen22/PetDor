import styles from "../styles/Home.module.css";
import Card from 'react-bootstrap/Card';
import Slider from "react-slick";

export default function VisualizarPet(props) {
  // const tutorId = props.tutorId;

  // console.log(tutorId);

  const petCollection = [
    {
      "nome": "Vilma", 
      "imagem": "https://c.pxhere.com/photos/d2/1a/yorkshire_terrier_dog_small_cute_pet_head-984543.jpg!s",
      "genero": "Femea", 
      "aniversario": "21/04", 
      "castrado": "true", 
      "animal": "Cachorro", 
      "raca": "PDB", 
      "descricao": "cachorrinha tchutchuca", 
      "tutorId": "01"
    },
    {
      "nome": "Fred", 
      "imagem": "https://c.pxhere.com/photos/dc/6b/dog_german_badger_pet_animal_buddy_brown_companion_dacshound-1070637.jpg!s",
      "genero": "Macho", 
      "aniversario": "18/02", 
      "castrado": "false", 
      "animal": "Cachorro", 
      "raca": "PDB", 
      "descricao": "cachorrinho brabo", 
      "tutorId": "01"
    }
  ];

  return (
    <div className={styles.viewCadastroPet}>
     
          {
            petCollection.map((pet, i) => {

              return (
                
                  <div>
                    
                    <Card border="primary" id={petCollection[i].nome}>
                      <Card.Header>{petCollection[i].nome}</Card.Header>
                      <Card.Body>
                        <Card.Text>
                          <p><span style={{fontWeight: "bold"}}>Animal: </span>{petCollection[i].animal}</p>
                          <p><span style={{fontWeight: "bold"}}>Castrado: </span>{(petCollection[i].castrado) ? "Sim" : "Não"}</p>
                          <p><span style={{fontWeight: "bold"}}>G&ecirc;nero: </span>{petCollection[i].genero}</p>
                          <p><span style={{fontWeight: "bold"}}>Anivers&aacute;rio: </span>{petCollection[i].aniversario}</p>
                          <p><span style={{fontWeight: "bold"}}>Descri&ccedil;&atilde;o: </span>{petCollection[i].descricao}</p>  
                        </Card.Text>
                      </Card.Body>
                    </Card>
                  
                  </div>
     
              )

            })
          }

    </div>
  );
}
