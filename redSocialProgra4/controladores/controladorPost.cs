﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using redSocialProgra4.modelos;

namespace redSocialProgra4.controladores
{
    public class controladorPost
    {
        public controladorPost() { }

        public List<Post> controladorMiMuro(string correo)
        {
            Post p = new Post();
            List<Post> lista = p.miMuro(correo);
            if (lista.Count==0)
            {
                p.Texto = "Su muro se encuentra vacio";
                lista.Add(p);
            }
            else
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    Usuario u = new Usuario();
                    Usuario u2 = u.buscaUno(lista[i].Creador);
                    lista[i].NombreCreador = u2.Nombre+" "+u2.Apellido;
                }
            }
            return lista;
        }
    }
}