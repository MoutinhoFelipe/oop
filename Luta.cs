using System;

class FightGame {
    static void Main() {
        string playerName;
        int playerStr;
        int playerDef;
        int playerAgi;
        int playerPontos = 50;
        Console.WriteLine("Digite o nome de seu Lutador: ");
        playerName = Console.ReadLine();
        Console.WriteLine("Você deverá distribuir 50 pontos entre Força, Defesa e Agilidade: ");
        do {
            Console.WriteLine("Você tem " + playerPontos + " pontos restantes para distribuir.");
            Console.WriteLine("Digite o valor de Força: ");
            playerStr = Int32.Parse(Console.ReadLine());
        } while (playerStr > playerPontos);
        playerPontos -= playerStr;
        do {
            Console.WriteLine("Você tem " + playerPontos + " pontos restantes para distribuir.");
            Console.WriteLine("Digite o valor de Defesa: ");
            playerDef = Int32.Parse(Console.ReadLine());
        } while (playerDef > playerPontos);
        playerPontos -= playerDef;

        playerAgi = 50 - playerStr - playerDef;
        Console.WriteLine("Para seu valor de Agilidade sobrou: " + playerAgi);

        Fighter f1 = new Fighter(playerName, playerStr, playerDef, playerAgi);
        Fighter f2 = new Fighter("Maguila", 15, 20, 15);
        //Fighter f2 = new Fighter("Neném", 15, 30, 5);
        Fight UFC1 = new Fight();
        UFC1.ft_fight(f1,f2);
    }
}

class Fighter {
    public string name;
    //public string type;
    public double life;
    public int strength;
    public int defense;
    public int quickness;

    //Amplitude do Golpe. (EX: 40 de força e 10 de range, golpe será aleatório entre 30 e 50)
    public int rangeInterval = 10; 

    //public bool dodge;

    public Fighter (string n, int str, int def, int qck) {
        this.name = n;
        this.life = 100;
        this.strength = str;
        this.defense = def;
        this.quickness = qck;
    }

    public int ftAttack() {
        int atk;
        int atk_inf = this.strength - this.rangeInterval;
            if (atk_inf < 0) {
                atk_inf = 0;
            }
        int atk_sup = this.strength + this.rangeInterval;
        Random rda = new Random();
        System.Threading.Thread.Sleep(10);
        atk = rda.Next(atk_inf,atk_sup);
        return atk;
    }

    public int ftDefend() {
        int def;
        int def_inf = this.defense - this.rangeInterval;
            if (def_inf < 0) {
                def_inf = 0;
            }
        int def_sup = this.defense + this.rangeInterval;
        Random rdd = new Random();
        System.Threading.Thread.Sleep(10);
        def = rdd.Next(def_inf,def_sup);
        return def;
    }

    public bool ftDodge() {
        int randomQuickness;
        int randomDodge;
        int quickInf = this.quickness - this.rangeInterval;
            if (quickInf < 0) {
                quickInf = 0;
            }
        int quickSup = this.quickness + this.rangeInterval;

        Random rd1 = new Random();
        System.Threading.Thread.Sleep(10);
        Random rd2 = new Random();
        randomQuickness = rd1.Next(quickInf,quickSup);
        //Console.WriteLine("Valor de Quickness do Turno: " + randomQuickness);
        randomDodge = rd2.Next(0,50);
        //Console.WriteLine("Valor Mínimo para conseguir Dodge no Turno: " + randomDodge); 
        if (randomDodge > randomQuickness) {
            return false;
        } else {
            return true;
        }
    }

    public void presentation() {
        int i = 0;

        Console.WriteLine("Nome do Lutador: " + this.name);
        Console.WriteLine("Atributos do Lutador: ");

        Console.Write("Força:     ");
        while (i < (this.strength)){
            Console.Write("|");
            i++;
        };
        Console.WriteLine(" " + this.strength);
        i = 0;

        Console.Write("Defesa:    ");
        while (i < (this.defense)){
            Console.Write("|");
            i++;
        };
        Console.WriteLine(" " + this.defense);
        i = 0;

        Console.Write("Agilidade: ");
        while (i < (this.quickness)){
            Console.Write("|");
            i++;
        };
        Console.WriteLine(" " + this.quickness);
        i = 0;
        Console.WriteLine(" _______________________________ ");
        //Console.WriteLine("Aperte Enter para prosseguir.");
        Console.ReadLine();
    }
}

class Fight {
    public void fight_presentation(Fighter f1, Fighter f2) {
        f1.presentation();
        f2.presentation();
        Console.WriteLine("Luta iniciada!");
        Console.WriteLine();
    }

    public void ft_fight(Fighter f1, Fighter f2) {
        double dmg;
        int round = 1;
        bool pTurn = true; //Verificar se é a vez do Player atacar.

        fight_presentation(f1, f2);

        // Rounds da Luta
        while ((f1.life > 0) && (f2.life > 0)) {

            //Mostrar Turno
            Console.WriteLine("Turno " + round);

            //Verificar se vai desviar do Golpe
            bool dodge1 = f1.ftDodge();
            bool dodge2 = f2.ftDodge();

            //Attack f1
            Console.WriteLine(f1.name + " está atacando: ");
            if (dodge2 == false) {
                dmg = ftDamage(f1,f2,pTurn);
                f2.life -= dmg;
            } else {
            Console.WriteLine(f2.name + " desviou completamente!");
            Console.WriteLine();
            }
            pTurn = !pTurn;

            //Attack f2
            Console.WriteLine(f2.name + " está atacando: ");
            if (dodge1 == false) {
                dmg = ftDamage(f1,f2,pTurn);
                f1.life -= dmg;
            } else {
            Console.WriteLine(f1.name + " desviou completamente!");
            Console.WriteLine();
            }
            pTurn = !pTurn;
            
            // Report de fim de Turno
            logFimTurno(f1,f2);
            round++;
        }
        if (f1.life <= 0) {
            Console.WriteLine("O vencedor é: " + f2.name);
        } else if (f2.life <= 0) {
            Console.WriteLine("O vencedor é: " + f1.name);
        }
    }

    public int ftDamage(Fighter f1, Fighter f2, bool pTurn) {
        if (pTurn == true) {
            int dmg_atk = f1.ftAttack();
            int dmg_def = f2.ftDefend();
            int dmg;
            dmg =  dmg_atk - dmg_def;
                if (dmg < 0) {
                    dmg = 0;
                }
            Console.WriteLine("Ataque: " + dmg_atk + " | Defesa de " + f2.name + ": " + dmg_def + " | Dano: " + dmg);
            Console.WriteLine();
            return dmg;
        } else {
            int dmg_atk = f2.ftAttack();
            int dmg_def = f1.ftDefend();
            int dmg;
            dmg =  dmg_atk - dmg_def;
                if (dmg < 0) {
                    dmg = 0;
                }
            Console.WriteLine("Ataque: " + dmg_atk + " | Defesa de " + f1.name + ": " + dmg_def + "| Dano: " + dmg);
            Console.WriteLine();
            return dmg;
        }
        
    }

    public void logFimTurno (Fighter f1, Fighter f2) {
        Console.WriteLine("Life atual");
        Console.WriteLine(f1.name +" : " + f1.life);
        Console.WriteLine(f2.name + " : " + f2.life);
        Console.WriteLine(" _______________________________ ");
        //Console.WriteLine("Aperte Enter para prosseguir.");
        Console.ReadLine();
        //System.Threading.Thread.Sleep(3000);
    }
}