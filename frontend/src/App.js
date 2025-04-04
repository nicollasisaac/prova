// src/App.js
import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Curriculo from './pages/Curriculo';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/curriculo" element={<Curriculo />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
