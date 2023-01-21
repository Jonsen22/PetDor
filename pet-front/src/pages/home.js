import styles from "../styles/Home.module.css";

export default function home(props) {


    return(
        <div className={styles.containerHome}>
            <div className={styles.menuHome}>
                <div className={styles.navbarHome}>
                    <span> Bem vindo, xxxx!</span>
                    <button>sair</button>
                </div>
                <div className={styles.menusHomePage}>
                  <div className={styles.consultasMenu}>
                    <div style={{borderBottom: "2px solid black", width: "100%",
                     textAlign: "center", padding: "10px"}}>
                        Próximas Consultas
                    </div>
                    <div>
                        aaaa
                    </div>
                  </div>
                  <div className={styles.petsMenu}>
                    <div className={styles.submenuPets}>
                        <span style={{marginLeft: "15px"}}>Seus Pets</span>
                        <span style={{marginRight: "15px"}}>+</span>
                    </div>
                    <div>

                    </div>
                  </div>
                </div>
            </div>
        </div>
    )

}