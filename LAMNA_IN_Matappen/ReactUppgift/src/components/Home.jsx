import { Link } from "react-router-dom";
import { FaArrowRight, FaHamburger, FaStar, FaClock } from "react-icons/fa";
import homepage from "../assets/homepage.jpg";

function Home() {
  return (
    <section className="home">
      <img src={homepage} alt="Mat" className="home-image" />
      <div className="home-overlay"></div>

      <div className="home-content">
        <span className="home-badge">
          <FaStar /> Färska rätter varje dag
        </span>

        <h1>Välkommen till Matappen</h1>

        <p>
          Upptäck goda maträtter, tydliga priser och enkla kategorier direkt
          från vår meny.
        </p>

        <div className="home-actions">
          <Link className="button primary-button" to="/mat">
            Visa menyn <FaArrowRight />
          </Link>

          <div className="small-info">
            <FaClock />
            Snabbt, enkelt och gott
          </div>
        </div>

        <div className="home-cards">
          <div>
            <FaHamburger />
            <strong>God mat</strong>
            <span>Se hela menyn</span>
          </div>

          <div>
            <FaStar />
            <strong>Bra priser</strong>
            <span>Alltid tydligt</span>
          </div>
        </div>
      </div>
    </section>
  );
}

export default Home;