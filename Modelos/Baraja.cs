using CartasEspañolas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartasEspaniolas 
{ 

public class Baraja
{
    public List<Carta> baraja { get; set; }

    public List<Carta> cartasSacadas { get; set; }

    public Baraja()
    {
        baraja = new List<Carta>();
        cartasSacadas = new List<Carta>();
        generarBaraja();
    }

    // Genera las cartas para la baraja
    private void generarBaraja()
    {
        for (int i = 0; i < Recursos.PALOS.Length; i++)
        {
            for (int j = Recursos.LIMITE_INFERIOR; j <= Recursos.LIMITE_SUPERIOR; j++)
            {
                if (!Recursos.EXCLUSIONES.Contains(j))
                {
                    baraja.Add(new Carta((byte)j, Recursos.PALOS[i]));
                }
            }
        }
    }

    // Cambia de posición todas las cartas aleatoriamente.
    public void barajar()
    {
        for (int i = 0; i < baraja.Count; i++)
        {
            Random random = new Random();
            int indice = random.Next(0, baraja.Count);
            Carta carta = baraja[i];
            baraja[i] = baraja[indice];
            baraja[indice] = carta;
        }
    }

    public Carta SiguienteCarta()
    {
        if (baraja.Count > 0)
        {
            Carta carta = baraja[0];
            cartasSacadas.Add(baraja[0]);
            baraja.RemoveAt(0);
            return carta;
        }
        else
        {
            return null;
        }
    }

    public int cartasDisponibles()
    {
        return baraja.Count();
    }

    public List<Carta> darCartas(int cantidad)
    {

        if (baraja.Count >= cantidad)
        {
            List<Carta> cartas = new List<Carta>();
            for (int i = 0; i < cantidad; i++)
            {
                cartas.Add(baraja[0]);
                cartasSacadas.Add(baraja[0]);
                baraja.RemoveAt(0);

            }
            return cartas;
        }
        else
        {
            return null;
        }
    }

    public List<Carta> cartasMonton()
    {
        if (cartasSacadas.Count > 0)
        {
            return cartasSacadas;
        }
        else
        {
            return null;
        }

    }

}
    }










//using CartasEspañolas.Modelos;

//    public class Baraja : Carta 
//    {
//        public List<Carta> Carta{ get; set; }
//        public List<Carta> MasoBarajado { get; set; }
//        public List<Carta> CartasRepartidas { get; set; }
//        public Baraja()
//        {
//           var Carta = new List<Carta>();
//            for (int numero = 1; numero <= 12; numero++)
//            {
//                var cartasEspada = new Cartas(numero, "Espada");
//                this.Carta.Add(cartasEspada);
//                if (cartasEspada.Numero==8|| cartasEspada.Numero==9)
//                    this.Carta.Remove(cartasEspada);
//            }
//            for (int numero = 1; numero <= 12; numero++)
//            {
//                var cartasBasto = new Cartas(numero, "Basto");
//                this.Carta.Add(cartasBasto);
//                if (cartasBasto.Numero == 8 || cartasBasto.Numero == 9)
//                    this.Carta.Remove(cartasBasto);
//            }    
//            for (int numero = 1; numero <= 12; numero++)
//            {
//                var cartasOro = new Cartas(numero, "Oro");
//                this.Carta.Add(cartasOro);
//                if (cartasOro.Numero == 8 || cartasOro.Numero == 9)
//                    this.Carta.Remove(cartasOro);
//            }
//            for (int numero = 1; numero <= 12; numero++)
//            {
//                var cartasCopa = new Cartas(numero, "Copa");
//                this.Carta.Add(cartasCopa);
//                if (cartasCopa.Numero == 8 || cartasCopa.Numero == 9)
//                    this.Carta.Remove(cartasCopa);
//            }
//        }
//        public void Barajar()
//        {
//            MasoBarajado = new List<Carta>();
//            CartasRepartidas = new List<Carta>();
//            Random aleatorio = new Random();
//            for (int i = 0; i < Carta.Count; i++)
//            {
//                Carta carta = Carta[i];
//                MasoBarajado.Insert(aleatorio.Next(MasoBarajado.Count), carta);
//            }
//            Console.WriteLine("Desea ver el maso barajado s/n ");
//            string opcion = Console.ReadLine();
//            do
//            {
//                switch (opcion.ToUpper())
//                {
//                    case "S":
//                        foreach (var carta in MasoBarajado)
//                        {                              
//                            Console.WriteLine(carta.Numero + " de " + carta.Palo);                         
//                        }
//                        Console.WriteLine("Presione cualquier tecla para retonar al menu principal");
//                        Console.ReadKey();
//                        Console.WriteLine("Retornando al menu principal");
//                        System.Threading.Thread.Sleep(3000);
//                        Console.Clear();
//                        opcion = "0";                          
//                        break;                                              
//                    case "N":
//                        Console.WriteLine("No se muestra el maso");
//                        Console.WriteLine("Retornando al menu principal");
//                        System.Threading.Thread.Sleep(3000);
//                        Console.Clear();  
//                        opcion = "0";
//                        break;
//                    default:
//                        Console.WriteLine("Opcion no valida, favor de ingresar una opcion correcta");
//                        opcion = Console.ReadLine();
//                        break;
//                }
//            } while (opcion!="0");
//        }
//        public void BarajarBack()
//        {
//            MasoBarajado = new List<Carta>();
//            CartasRepartidas = new List<Carta>();
//            Random aleatorio = new Random();
//            for (int i = 0; i < Carta.Count; i++)
//            {
//                Carta carta = Carta[i];
//                MasoBarajado.Insert(aleatorio.Next(MasoBarajado.Count), carta);
//            }
//        }
//        public void DarCartas(int cantidad)
//        {
//            if (MasoBarajado == null)
//            {
//                BarajarBack();
//            }
//            Console.WriteLine("El maso se está barajando");          
//            System.Threading.Thread.Sleep(1000);
//            Console.Write("*");
//            System.Threading.Thread.Sleep(1000);
//            Console.Write("*");
//            System.Threading.Thread.Sleep(1000);
//            Console.Write("*");
//            Console.WriteLine();
//            System.Threading.Thread.Sleep(1000);
//            BarajarBack();           
//            if (cantidad <= MasoBarajado.Count)
//            {
//                for (int i = 0; i <= cantidad; i++)
//                {
//                    Carta cartaASalir = MasoBarajado[i];
//                    MasoBarajado.Remove(cartaASalir);
//                    Carta.Remove(cartaASalir);
//                    CartasRepartidas.Add(cartaASalir);
//                    Console.WriteLine($"{cartaASalir.Numero} de {cartaASalir.Palo}");
//                }
//            }
//            else
//            {
//                Console.WriteLine("No hay suficientes cartas");
//            }
//        }

//        public string SiguienteCarta()
//        {
//            if (MasoBarajado==null)
//            {
//                BarajarBack();
//            }
//                int posicion = 0;
//                Carta cartaSiguiente = MasoBarajado[posicion];
//                MasoBarajado.Remove(cartaSiguiente);
//                Carta.Remove(cartaSiguiente);
//                CartasRepartidas.Add(cartaSiguiente);
//                posicion++;              
//                if (posicion <= MasoBarajado.Count)
//                {
//                    return ($"{cartaSiguiente.Numero} de {cartaSiguiente.Palo}");
//                }
//                else
//                {
//                    return ("No hay mas cartas disponibles en el maso");
//                }
//        }
//        public void CartasMonton()
//        {
//            if (MasoBarajado == null)
//            {
//                BarajarBack();
//            }          
//                if (CartasRepartidas.Count == 0)
//                {
//                    Console.WriteLine("No se han repartido cartas aun");
//                }
//                else
//                {
//                    Console.WriteLine("Cartas del monton");
//                    foreach (var item in CartasRepartidas)
//                    {
//                        Console.WriteLine($"{item.Numero} de {item.Palo}");
//                    }
//                }
//        }
//        public string CartasDisponibles()
//        {
//            if (MasoBarajado == null)
//            {
//                BarajarBack();
//            }
//            return ($"Quedan {MasoBarajado.Count} cartas disponibles");
//        }
//        public void MostrarBaraja()
//        {
//            Console.WriteLine("*********************************************************");
//            foreach (var item in Carta)
//            {
//                Console.WriteLine($"{item.Numero} de {item.Palo}");
//                if (item.Numero == 12) 
//                {
//                    Console.WriteLine("*********************************************************");
//                }
//            }
//            Console.WriteLine("Presione cualquier tecla para continuar");
//            Console.ReadKey();
//        }
//    }