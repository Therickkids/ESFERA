using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D; // Necesario para GraphicsPath y la región circular
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejemplo
{
    public partial class fmrWinMode : Form
    {
        private int velocityY = 0; // Velocidad en el eje Y (para el rebote)
        private int gravity = 2; // Gravedad que afecta la esfera
        private int groundLevel; // Nivel del suelo donde la esfera debe rebotar
        private const float bounceFactor = 0.8f; // Factor de amortiguación para reducir la fuerza del rebote
        private int createRadius = 0; // Radio de la esfera en proceso de creación
        private Timer createTimer; // Timer para la animación de creación

        public fmrWinMode()
        {
            InitializeComponent();
            this.Load += fmrWinMode_Load; // Vincula el evento Load al método fmrWinMode_Load
        }

        private void fmrWinMode_Load(object sender, EventArgs e)
        {
            // Configurar el PictureBox que representa la esfera (usando picUFO)
            picUFO.BackColor = Color.Red; // El color de la esfera
            picUFO.Width = 0; // Ancho inicial de la esfera
            picUFO.Height = 0; // Alto inicial de la esfera
            picUFO.Top = 0; // Posición inicial en la parte superior de la ventana
            picUFO.Left = (this.ClientSize.Width - picUFO.Width) / 2; // Centrar horizontalmente

            // Crear un Timer para la animación de creación
            createTimer = new Timer();
            createTimer.Interval = 50; // Intervalo de 50ms
            createTimer.Tick += tmrCreate_Tick;
            createTimer.Start();

            // Crear una región circular para hacer que el PictureBox parezca una esfera
            UpdateSphereRegion();

            // Definir el nivel del suelo basado en el tamaño del formulario
            groundLevel = this.ClientSize.Height - 50; // Asumimos el tamaño final de la esfera

            // Inicializar el timer para controlar el movimiento de la esfera
            tmrUFO.Interval = 20; // Intervalo de 20ms (50fps aprox)
            tmrUFO.Tick += tmr_Tick;
        }

        private void tmrCreate_Tick(object sender, EventArgs e)
        {
            if (createRadius < 25) // Suponemos que el radio final es 25 (para un tamaño final de 50x50)
            {
                createRadius++;
                picUFO.Width = createRadius * 2;
                picUFO.Height = createRadius * 2;
                picUFO.Left = (this.ClientSize.Width - picUFO.Width) / 2; // Recentrar horizontalmente
                UpdateSphereRegion();
            }
            else
            {
                createTimer.Stop();
                tmrUFO.Start(); // Empezar el rebote
            }
        }

        private void UpdateSphereRegion()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, picUFO.Width, picUFO.Height);
            picUFO.Region = new Region(path); // Asignar la región circular al PictureBox
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            // Aplicar gravedad
            velocityY += gravity;
            picUFO.Top += velocityY;

            // Detectar colisión con el suelo
            if (picUFO.Top >= groundLevel)
            {
                picUFO.Top = groundLevel; // Asegurarse de que la esfera no traspase el suelo

                // Hacer rebotar la esfera cambiando la dirección de la velocidad Y
                velocityY = (int)(-velocityY * bounceFactor);
            }

            // Si la velocidad es mínima, darle un pequeño impulso para que continúe rebotando
            if (Math.Abs(velocityY) < 2 && picUFO.Top >= groundLevel)
            {
                velocityY = -35;
            }
        }
    }
}

