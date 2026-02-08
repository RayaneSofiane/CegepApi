using APIGestionCegep.Logics.Controleurs;
using APIGestionCegep.Logics.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CegepApi.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class CegepController : ControllerBase
    {
        /// <summary>
        ///  fonction qui obtien la liste des cegeps
        /// </summary>
        /// <returns>la liste des cegeps</returns>
        [Route("ObtenirListeCegeps")]
        [HttpGet]
        public IActionResult ObtenirListeCegeps()
        {
            try
            {
                IEnumerable<CegepDTO> listeCegep = CegepControleur.Instance.ObtenirListeCegep();
                return Ok(listeCegep);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        /// <summary>
        /// obtien le cegep en utilisant le nom
        /// </summary>
        /// <param name="nomCegep">le nom du cegep voulu</param>
        /// <returns>le cegep</returns>
        [Route("ObtenirCegep")]
        [HttpGet]
        public CegepDTO ObtenirCegep(string nomCegep)
        {
            return CegepControleur.Instance.ObtenirCegep(nomCegep);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cegep"></param>
        /// <returns></returns>
        [Route("AjouterCegep")]
        [HttpPost]
        public IActionResult AjouterCegep([FromBody] CegepDTO cegep)
        {
            try
            {
                CegepControleur.Instance.AjouterCegep(cegep);
                return Ok(cegep);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        /// <summary>
        /// modifie le cegep en utilisant le nom
        /// </summary>
        /// <param name="cegep">nom du cegep a modifier</param>
        /// <returns></returns>
        [Route("ModifierCegep")]
        [HttpPut]
        public IActionResult ModifierCegep([FromBody] CegepDTO cegep)
        {
            try
            {
                CegepControleur.Instance.ModifierCegep(cegep);
                return Ok(cegep);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        /// <summary>
        /// supprime le cegep en utilisant un nom
        /// </summary>
        /// <param name="nomCegep">le nom du cegep</param>
        /// <returns></returns>
        [Route("SupprimerCegep")]
        [HttpDelete]
        public IActionResult SupprimerCegep(string nomCegep)
        {
            try
            {
                CegepControleur.Instance.SupprimerCegep(nomCegep);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        /// <summary>
        /// supprime la liste des cegeps
        /// </summary>
        /// <returns></returns>
        [Route("ViderListeCegeps")]
        [HttpDelete]
        public IActionResult ViderListeCegeps()
        {
            try
            {
                CegepControleur.Instance.ViderListeCegep();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}