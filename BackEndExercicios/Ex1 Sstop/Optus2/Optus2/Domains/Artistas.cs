﻿using System;
using System.Collections.Generic;

namespace Optus2.Domains
{
    public partial class Artistas
    {
        public int IdArtista { get; set; }
        public string Nome { get; set; }
        public int? IdEstilo { get; set; }

        public Estilos IdEstiloNavigation { get; set; }
        public object IdArtistaNavegation { get; internal set; }
    }
}
