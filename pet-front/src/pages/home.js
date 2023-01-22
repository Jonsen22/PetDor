import VisualizarPet from "../components/visualizarPets";
import styles from "../styles/Home.module.css";
import VisualizarConsultas from "../components/visualizarConsultas";



export default function home(props) {
  return (
    <div className={styles.containerHome}>
      <div className={styles.menuHome}>
        <div className={styles.navbarHome}>
          <span> Bem vindo, xxxx!</span>
          <button  className={styles.buttonLogout} >sair</button>
        </div>
        <div className={styles.menusHomePage}>
          <div className={styles.consultasMenu}>
            <div className={styles.submenuConsulta}>
              <span style={{ marginLeft: "15px" }}>Consultas</span>
              <button  className={styles.buttonLogin} style={{ marginRight: "5px" }}>Marcar consulta</button>
            </div>
            {/* <VisualizarConsultas/> */}
          </div>
          <div className={styles.petsMenu}>
            <div className={styles.submenuPets}>
              <span style={{ marginLeft: "15px" }}>Seus Pets</span>
              <button  className={styles.buttonLogin} style={{ marginRight: "15px" }}>+</button>
            </div>
            <VisualizarPet style={{ border: "5px solid green" }} />
            <div></div>
          </div>
        </div>
      </div>
    </div>
  );
}
