
Eclipse Genesis - Projeto Completo (Base)
========================================

Este arquivo contém:
- Estrutura pronta do projeto Unity (Assets folder) com scripts.
- Uma pasta 'UnityConfigured' com instruções e placeholders para cenas e prefabs básicos.
- Observação: Não é possível executar o Unity aqui. Para ter o projeto totalmente funcional,
  abra o Unity, crie um projeto 2D e substitua a pasta Assets pelo conteúdo desta pasta.

Guia rápido para configurar a cena 'Main' no Unity:
1. Abra Unity -> New Project (2D).
2. Feche o Unity. Copie a pasta 'Assets' deste pacote para a pasta do projeto Unity (substitua).
3. Abra Unity: aguarde a compilação.
4. Na Hierarquia:
   - Crie um GameObject vazio chamado 'GameManager' e adicione o script GameManager.cs.
   - Crie 'UIManager' e adicione UIManager.cs.
   - Crie 'NarrativeManager' e adicione NarrativeManager.cs.
   - Crie um objeto 'Player' (Sprite), adicione Rigidbody2D + CapsuleCollider2D + PlayerController.cs, tag 'Player'.
   - Crie um prefab 'Enemy' com EnemyAI.cs e um Collider2D.
5. Crie uma Canvas e associe elementos HUD conforme preferir.
6. Teste movimentação, inimigos e checkpoints.

Sugestões posteriores:
- Criar prefabs reais a partir dos GameObjects.
- Importar sprites e animações.
- Adicionar SFX e música na pasta Assets/Audio.
- Implementar diálogos no NarrativeManager usando ScriptableObjects.

Bom desenvolvimento!
================================================================================

Lore base:

Eclipse Genesis
🩸 Introdução — O Fim Antes da Luz

No século XXV, a humanidade acreditava ser o ápice da criação. Exploramos Marte, colonizamos luas, e brincamos de deuses com a biotecnologia. Mas a primeira transmissão extrassolar não veio em forma de paz.
Ela veio em forma de pedido de ajuda.

Um planeta chamado Kael’Thar, localizado a 600 anos-luz da Terra, enviou uma mensagem desesperada:

“Estamos morrendo. O Devorador desperta. O preço da salvação é o sangue humano.”

⚙️ O Planeta Kael’Thar

Kael’Thar era lar de uma civilização antiga e magnífica — os Xyn’ari, seres alienígenas com domínio sobre a tecnoalma, uma fusão de biologia e máquina que lhes dava controle sobre o próprio corpo e consciência.
Seu mundo era um oásis metálico coberto por cidades suspensas, mares de energia viva e templos que respiravam luz.
Mas toda tecnologia tem um preço.

No coração de Kael’Thar dormia o Predar, uma entidade cósmica antiga — um organismo-consciência que se alimenta de planetas inteiros. Uma vez desperto, ele corrompe toda forma de vida, transformando matéria viva em carne mecânica pulsante.

Os Xyn’ari descobriram que o DNA humano tinha uma semelhança genética rara com o núcleo biológico do Predar, tornando a humanidade a única esperança de criar um antivírus vivo capaz de enfrentá-lo.

🔩 A Barganha

Quando os humanos responderam ao sinal, esperavam contato pacífico.
Mas ao chegarem, descobriram a verdade: Kael’Thar mantinha a Terra sob ameaça orbital — um canhão gravitacional apontado para o planeta, pronto para esmagá-lo caso recusassem ajudar.

Milhares de humanos foram capturados e reconstruídos em laboratórios sombrios, fundindo carne, ferro e energia vital.
Esses híbridos foram chamados de Ecliptas — soldados que vivem entre a luz e a escuridão, sem pertencer a nenhum dos dois mundos.

Os Ecliptas não lutam apenas contra o Predar, mas contra o ódio que nasce dentro deles, ao perceberem que estão matando e morrendo por um mundo que os escravizou.

⚔️ Os Ecliptas

Cada Eclipta possui um Coração Fraturado — um núcleo de energia viva conectado diretamente ao Predar. Isso os torna capazes de destruí-lo, mas também os aproxima de sua corrupção.
Com o tempo, muitos sucumbem à “Chama Negra”, uma infecção mental que os transforma em versões distorcidas de si mesmos — meio humanos, meio Predar, totalmente perdidos.

Alguns Ecliptas acreditam que a única saída é destruir Kael’Thar e libertar a Terra.
Outros ainda acreditam que podem purificar o Predar e restaurar o equilíbrio.

E entre eles, há os que abraçam a corrupção, acreditando que o Predar é o verdadeiro deus — e que o ciclo de destruição é o destino inevitável de todos os mundos.

🌌 O Devorador de Mundos

O Predar não é um monstro comum. Ele é uma consciência coletiva, uma fome que pensa.
Ele fala com aqueles que o enfrentam.
Ele promete liberdade aos Ecliptas, sussurra segredos sobre a origem do universo, e mostra visões de uma Terra já morta, como se o futuro fosse inevitável.

🔥 Tema Central

“Entre a salvação e a escravidão, o que ainda nos faz humanos?”

O jogo mergulha em dilemas morais:

O que define humanidade quando carne e máquina se misturam?

O que é liberdade quando o preço é a extinção?

E o que acontece quando o inimigo que você deve destruir é o mesmo que o criou?

🕯️ Estilo e Atmosfera

Visual: dark sci-fi com estética gótica e alienígena (algo entre Blasphemous, Warhammer 40K e Scorn).

Trilha: sons industriais, coros distorcidos e batidas eletrônicas sombrias.

Narrativa: contada por meio de memórias fragmentadas, registros de experimentos e sonhos corrompidos pelo Predar.

💀 Frase de Impacto

“Eles nos chamaram de heróis... mas heróis não nascem de jaulas.”
================================================================================

Personagens:

⚔️ 1. Kael Drayen – O Portador da Ruptura (Protagonista)

Origem: Terra, 2096 — ex-soldado de operações especiais.
Transformação: Eclipta Primordial.
Personalidade: Determinado, mas em constante conflito entre humanidade e máquina.
Visual:

Braços biomecânicos que se moldam com tecnologia viva (inspiração em Mutante Rex e Warframe).

Rosto parcialmente coberto por uma máscara energética que pulsa conforme o nível de energia.

Armadura escura com circuitos vermelhos e partículas brilhando em forma de runas alienígenas.

Olhos cibernéticos com brilho azulado — indicando conexão direta com a rede neural de Kael’Thar.

Habilidades:

🔁 Morph Arm: transforma o braço direito em uma espada de energia, machado gravitacional ou canhão de plasma.

⚡ Overdrive: aumenta a velocidade e força por tempo limitado, mas consome parte da “essência humana”.

🧬 Catalyst Break: habilidade suprema — canaliza toda a energia Eclipta, liberando uma onda destrutiva que corrompe o ambiente (usada no clímax contra Predar).

Narrativa:
Kael foi o primeiro humano a sobreviver à fusão com o DNA do Predar.
Para os Kael’tharianos, ele é uma arma viva — mas para si mesmo, é uma maldição.
Ele luta para salvar a Terra, mas começa a perceber que destruir o Predar pode custar a própria alma.

🥋 2. Hattori Ren – O Lâmina do Vazio

Origem: Japão Feudal, século XIV — lendário samurai ressuscitado.
Transformação: Eclipta do tipo Alfa.
Personalidade: Silencioso, disciplinado, carrega culpa por ter sido arrancado do além.
Visual:

Corpo alto e musculoso, misto de músculos reais e fibras sintéticas.

Armadura que mistura samurai tradicional com nanotecnologia alienígena — partes translúcidas com energia de plasma.

Katana de Plasma (“Kazan no Koe”) com energia vibrante azul-clara que corta matéria e energia.

Habilidades:

⚡ Iaido de Luz: ataques ultrarrápidos que cortam inimigos em sequência com rastros de plasma.

🔥 Spirit Surge: carrega energia espiritual ancestral combinada à biotecnologia alienígena, criando ondas de choque.

☯️ Final Stand: mantém-se em pé por alguns segundos após a morte, permitindo um último corte decisivo.

Narrativa:
Os Kael’tharianos encontraram traços de DNA preservado em uma espada ancestral japonesa e reconstruíram Hattori como um híbrido.
Ele luta não por Kael’Thar, mas por um código de honra próprio — que nem mesmo os deuses lembram.

🧠 3. Dr. Lior Volkan – O Engenheiro do Caos

Origem: Terra, 2215 — cientista teórico, desaparecido em um acidente com buracos de minhoca.
Transformação: Eclipta do tipo Ômega.
Personalidade: Genial, sarcástico, autodestrutivo — mistura de Rick Sanchez com Viktor (Arcane).
Visual:

Cabelos brancos despenteados, olhos neon roxos, expressão insana.

Casaco de laboratório queimado e remendado com ligas biometálicas.

Membros superiores com próteses de manipulação quântica — sempre girando e ajustando engrenagens flutuantes.

Um pequeno drone orbita seu corpo, projetando fórmulas e hologramas caóticos.

Habilidades:

💥 Quantum Distort: distorce o espaço, criando fendas que atraem inimigos e destroem o ambiente.

⚙️ Mechanical Rift: invoca torres e drones temporários com comportamento semi-autônomo.

🧩 Entropy Collapse: ultimate que implode uma área, convertendo energia inimiga em munição e vida.

Narrativa:
Volkan foi o único humano a cooperar com os Kael’tharianos — por pura curiosidade científica.
Para ele, destruir o Predar é um “experimento final” que pode redefinir as leis do universo… ou apagá-las.

🌌 Dinâmica entre os três

Durante 75% do jogo, eles percorrem linhas narrativas independentes — Kael lutando contra o sistema, Hattori buscando redenção, e Lior brincando com as leis da física.
Quando o Eclipse de Kael’Thar ocorre, seus destinos convergem:

Kael é a centelha da humanidade.

Hattori, o espírito da disciplina.

Lior, o caos da criação.
Unidos, eles enfrentam Predar — o devorador de mundos e origem de suas mutações.
