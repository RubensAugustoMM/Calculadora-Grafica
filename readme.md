# 📈 Calculadora Gráfica com OpenTK

Uma aplicação de desktop desenvolvida em **C#** que utiliza a biblioteca **OpenTK** (wrapper para OpenGL) para renderização gráfica de alta performance. O objetivo deste projeto é fornecer uma ferramenta capaz de plotar funções matemáticas em um ambiente 2D/3D otimizado.

---

## 🛠️ Tecnologias Utilizadas

- **C# / .NET**: Linguagem principal e ecossistema.
- **OpenTK**: Para integração com OpenGL e controle da GPU.
- **Lógica Matemática**: Implementação manual de algoritmos de projeção e renderização de eixos cartesianos.

---

## 🌟 Funcionalidades e Diferenciais

- **Renderização em Tempo Real**: Utiliza a GPU para garantir que a plotagem seja fluida, mesmo com funções complexas.
- **Sistema de Coordenadas**: Implementação de um plano cartesiano dinâmico com suporte a zoom e movimentação (Pan).
- **Abstração Gráfica**: O projeto demonstra conhecimentos de computação gráfica básica, como buffers (VBOs, VAOs) e Shaders.

---

## 🏗️ Arquitetura do Projeto

Ao contrário de bibliotecas de alto nível, este projeto lida com o ciclo de vida da renderização gráfica:
1. **Initialize**: Configuração do estado do OpenGL.
2. **OnUpdate**: Cálculo da lógica matemática e atualização de coordenadas.
3. **OnRender**: Limpeza do buffer e desenho das primitivas gráficas.

---

## 🚀 Como Executar o Projeto

### Pré-requisitos
- **SDK do .NET 8.0** (ou superior) instalado.
- Driver de vídeo atualizado (suporte a OpenGL).

### Passo a Passo
1. **Clone o repositório:**
```bash
git clone git@github.com-rubens:RubensAugustoMM/Calculadora-Grafica.git