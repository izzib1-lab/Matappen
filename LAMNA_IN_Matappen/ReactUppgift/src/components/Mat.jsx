import { useEffect, useState } from "react";
import { FaUtensils, FaTag, FaMoneyBillWave, FaInfoCircle, FaPlus } from "react-icons/fa";

const API_URL = "http://localhost:5037/api/Mat";

function Mat() {
  const [foodItems, setFoodItems] = useState([]);
  const [form, setForm] = useState({
    namn: "",
    beskrivning: "",
    kategori: "",
    pris: "",
  });

  async function getFoodItems() {
    const response = await fetch(API_URL);
    const data = await response.json();
    setFoodItems(data);
  }

  useEffect(() => {
    getFoodItems();
  }, []);

  async function handleSubmit(e) {
    e.preventDefault();

    const newFood = {
      namn: form.namn,
      beskrivning: form.beskrivning,
      kategori: form.kategori,
      pris: Number(form.pris),
    };

    await fetch(API_URL, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(newFood),
    });

    setForm({
      namn: "",
      beskrivning: "",
      kategori: "",
      pris: "",
    });

    getFoodItems();
  }

  return (
    <main className="menu-page">
      <section className="menu-hero">
        <h1>Vår Meny</h1>
        <p>Lägg till nya maträtter och visa dem i menyn.</p>
      </section>

      <form className="food-form container" onSubmit={handleSubmit}>
        <h2>
          <FaPlus /> Lägg till mat
        </h2>

        <input
          type="text"
          placeholder="Namn"
          value={form.namn}
          onChange={(e) => setForm({ ...form, namn: e.target.value })}
          required
        />

        <input
          type="text"
          placeholder="Beskrivning"
          value={form.beskrivning}
          onChange={(e) => setForm({ ...form, beskrivning: e.target.value })}
        />

        <input
          type="text"
          placeholder="Kategori"
          value={form.kategori}
          onChange={(e) => setForm({ ...form, kategori: e.target.value })}
          required
        />

        <input
          type="number"
          placeholder="Pris"
          value={form.pris}
          onChange={(e) => setForm({ ...form, pris: e.target.value })}
          required
        />

        <button type="submit">
          <FaPlus /> Lägg till
        </button>
      </form>

      <section className="food-grid container">
        {foodItems.map((food) => (
          <article className="food-card" key={food.id}>
            <div className="food-top">
              <div className="food-icon">
                <FaUtensils />
              </div>

              <span className="price">
                <FaMoneyBillWave /> {food.pris} SEK
              </span>
            </div>

            <h2>{food.namn}</h2>

            <p className="description">
              <FaInfoCircle /> {food.beskrivning}
            </p>

            <div className="category">
              <FaTag /> {food.kategori}
            </div>
          </article>
        ))}
      </section>
    </main>
  );
}

export default Mat;