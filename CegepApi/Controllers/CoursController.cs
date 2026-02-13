using APIGestionCegep.Logics.Controleurs;
using APIGestionCegep.Logics.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CegepApi.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public class CoursController : ControllerBase
        {
            /// <summary>
            /// obtien la liste des cours d'un cegep en utilisant le nom du cegep
            /// </summary>
            /// <param name="nomCegep"> le cegep qui pocede les departements </param>
            /// <param name="nomDepartement"> le departement qui pocede le cours </param>
            /// <returns>la liste des cours du departement</returns>
            [Route("ObtenirListeCours")]
            [HttpGet]
            public IActionResult ObtenirListeCours(string nomCegep, string nomDepartement)
            {
                try
                {
                    IEnumerable<CoursDTO> listeCours = CegepControleur.Instance.ObtenirListeCours(nomCegep, nomDepartement);
                    return Ok(listeCours);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }

            /// <summary>
            /// obtien un cours d'un cegep en utilisant le nom du cegep et le nom du departement et le nom du cours
            /// </summary>
            /// <param name="nomCegep">le nom du cegep</param>
            /// <param name="nomDepartement">le nom du departement</param>
            /// <param name="nomCours"> le nom du cours </param>
            /// <returns>le cours voulu</returns>
            [Route("ObtenirCours")]
            [HttpGet]
            public IActionResult ObtenirCours(string nomCegep, string nomDepartement,string nomCours)
            {
                try
                {
                    IEnumerable<CoursDTO> cours = (IEnumerable<CoursDTO>)CegepControleur.Instance.ObtenirCours(nomCegep, nomDepartement,nomCours);
                    return Ok(cours);
                }
                catch (Exception e)
                {

                    return BadRequest(e);
                }

            }
        /// <summary>
        /// ajoute un cour a un departement en utilisant le nom du cegep et du departement
        /// </summary>
        /// <param name="nomCegep">le nom du cegep</param>
        /// <param name="nomDepartement">le nom du departement</param>
        /// <param name="cours">le cours a ajouter</param>
        /// <returns></returns>
        [Route("AjouterCours")]
            [HttpPost]
            public IActionResult AjouterCours(string nomCegep,string nomDepartement, [FromBody] CoursDTO cours)
            {
                try
                {
                    CegepControleur.Instance.AjouterCours(nomCegep, nomDepartement,cours);
                    return Ok(cours);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
            /// <summary>
            /// modifie un cours en utilisant le nom du cegep et du departement et du cours
            /// </summary>
            /// <param name="nomCegep">le nom du cegep</param>
            /// <param name="nomDepartement">le nom du departement</param>
            /// <param name="cours">le cours a modifier</param>
            /// <returns></returns>
            [Route("ModifierCours")]
            [HttpPut]
            public IActionResult ModifierCours(string nomCegep,string nomDepartement, [FromBody] CoursDTO cours)
            {
                try
                {
                    CegepControleur.Instance.ModifierCours(nomCegep, nomDepartement, cours);
                    return Ok(cours);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
            /// <summary>
            /// suprime un cours en utilisant le nom du cegep du departement et du cours
            /// </summary>
            /// <param name="nomCegep">le nom du cegep</param>
            /// <param name="nomDepartement">le nom du departement</param>
            /// <param name="nomCours">le no du cours</param>
            /// <returns></returns>
            [Route("SupprimerCours")]
            [HttpDelete]
            public IActionResult SupprimerCours(string nomCegep, string nomDepartement, string nomCours)
            {
                try
                {
                    CegepControleur.Instance.SupprimerCours(nomCegep, nomDepartement,nomCours);
                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
            /// <summary>
            /// vide la liste des cours d'un departement en utilisant le nom du cegep et du departement
            /// </summary>
            /// <param name="nomCegep">le nom du cegep </param>
            /// <returns></returns>
            [Route("ViderListeCegeps")]
            [HttpDelete]
            public IActionResult ViderListeCours(string nomCegep,string nomDepartement)
            {
                try
                {
                    CegepControleur.Instance.ViderListeCours(nomCegep,nomDepartement);
                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
        }
    }

