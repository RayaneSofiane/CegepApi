using APIGestionCegep.Logics.Controleurs;
using APIGestionCegep.Logics.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CegepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentControler : ControllerBase
    {
        /// <summary>
        /// obtien la liste des departements d'un cegep en utilisant le nom du cegep
        /// </summary>
        /// <param name="nomCegep"> le cegep qui pocede les departements </param>
        /// <returns>la liste des departements</returns>
        [Route("ObtenirListeDepartement")]
            [HttpGet]
            public IActionResult ObtenirListeDepartement(string nomCegep)
            {
                try
                {
                    IEnumerable<DepartementDTO> listeDepartement = CegepControleur.Instance.ObtenirListeDepartement(nomCegep);
                    return Ok(listeDepartement);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
        /// <summary>
        /// obtien un departement d'un cegep en utilisant le nom du cegep et le nom du departement
        /// </summary>
        /// <param name="nomCegep">le nom du cegep</param>
        /// <param name="nomDepartement">le nom du departement</param>
        /// <returns>le departement voulu</returns>
        [Route("ObtenirDepartement")]
            [HttpGet]
            public IActionResult ObtenirCegep(string nomCegep,string nomDepartement)
            {
            try
            {
                IEnumerable<DepartementDTO> departement = (IEnumerable<DepartementDTO>)CegepControleur.Instance.ObtenirDepartement(nomCegep, nomDepartement);
                return Ok(departement);
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
               
            }
        /// <summary>
        /// ajoute un departement a un cegep en utilisant le nom du cegep et du departement
        /// </summary>
        /// <param name="nomCegep">le nom du cegep</param>
        /// <param name="departement">le nom du departement</param>
        /// <returns></returns>
        [Route("AjouterDepartement")]
            [HttpPost]
            public IActionResult AjouterDepartement(string nomCegep,[FromBody] DepartementDTO departement )
            {
                try
                {
                    CegepControleur.Instance.AjouterDepartement(nomCegep,departement);
                    return Ok(departement);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
        /// <summary>
        /// modiie un departement en utilisant le nom du cegep et du departement
        /// </summary>
        /// <param name="nomCegep"></param>
        /// <param name="departement"></param>
        /// <returns></returns>
        [Route("ModifierDepartement")]
            [HttpPut]
            public IActionResult ModifierDepartement(string nomCegep, [FromBody] DepartementDTO departement)
        {
                try
                {
                    CegepControleur.Instance.ModifierDepartement(nomCegep,departement);
                    return Ok(departement);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
        /// <summary>
        /// suprime un departement en utilisant le nom du cegep et du departement
        /// </summary>
        /// <param name="nomCegep">le nom du cegep</param>
        /// <param name="departement">le nom du departement</param>
        /// <returns></returns>
        [Route("SupprimerDepartement")]
            [HttpDelete]
            public IActionResult SupprimerDepartement(string nomCegep, string departement)
            {
                try
                {
                    CegepControleur.Instance.SupprimerDepartement( nomCegep,  departement);
                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
        /// <summary>
        /// vide la liste des departements d'un cegep en utilisant le nom du cegep
        /// </summary>
        /// <param name="nomCegep">le cegep a vider</param>
        /// <returns></returns>
        [Route("ViderListeCegeps")]
            [HttpDelete]
            public IActionResult ViderListeDepartement(string nomCegep)
            {
                try
                {
                    CegepControleur.Instance.ViderListeDepartement(nomCegep);
                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
        }
}
