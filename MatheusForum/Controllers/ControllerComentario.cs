﻿using AutoMapper;
using Core;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace APIForum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private IMapper _mapper { get; set; }
        public ComentarioController(IMapper mapper) => _mapper = mapper;

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult buscarComentarioPorID(string id, [FromHeader] string id_user)
        {
            var idcoment = new ComentarioCore(_mapper).buscaIdComentario(id_user, id);
            return idcoment.Status ? 
                Ok(idcoment) : 
                (IActionResult)BadRequest(idcoment);
        }

        // POST api/values
        [HttpPost]
        public IActionResult criaComentario([FromBody] ComentarioView comentarioView, [FromHeader] string id_user)
        {
            var coment = new ComentarioCore(comentarioView, _mapper).cadastraComentario(id_user);
            return coment.Status ? 
                Ok(coment) : 
                (IActionResult)BadRequest(coment);
        }

        // PUT api/values/5
        [HttpPut("{publicacaoID}")]
        public IActionResult atualizarComentario([FromHeader] string id_user, [FromBody] ComentarioAtualizacaoView ComentarioView, string id_comentario)
        {
            var comentAtualiza = new ComentarioCore(_mapper).atualizaComentario(id_user, ComentarioView, id_comentario);
            return comentAtualiza.Status ?
                Ok(comentAtualiza) : 
                (IActionResult)BadRequest(comentAtualiza);
        }

        // DELETE api/values/5
        [HttpDelete("{IdPublicacao}")]
        public IActionResult deletaComentario(string id_comentario, [FromHeader] string id_user)
        {
            var comentDeletado = new ComentarioCore(_mapper).deleteComentario(id_comentario, id_user);
            return comentDeletado.Status ? 
                Ok(comentDeletado) :
                (IActionResult)BadRequest(comentDeletado);
        }
    }
}