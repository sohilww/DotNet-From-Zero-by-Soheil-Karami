import clsx from "clsx";
import Heading from "@theme/Heading";
import styles from "./styles.module.css";

const FeatureList = [
  {
    title: "A Path to Real Programming",
    Svg: require("@site/static/img/undraw_docusaurus_mountain.svg").default,
    description: (
      <>
        This course is designed to help you become a real junior developer —
        someone who not only writes code, but thinks like a problem solver.
        You'll learn programming fundamentals from scratch and develop the
        mindset needed to build clean and efficient solutions.
      </>
    ),
  },
  {
    title: "Focus on What Matters",
    Svg: require("@site/static/img/undraw_docusaurus_tree.svg").default,
    description: (
      <>
        The entire journey is focused on building a solid foundation, thinking
        critically, and getting job-ready with clean, maintainable code. You
        won't just memorize syntax — you'll learn how to approach real-world
        problems and write solutions that are easy to understand, test, and
        grow.
      </>
    ),
  },
  {
    title: "What We Expect from You",
    Svg: require("@site/static/img/undraw_docusaurus_react.svg").default,
    description: (
      <>
        This course is just the beginning — not the end. What we ask from you is
        simple but powerful: Keep the learning chain alive. Share what you've
        learned. Teach others — even if it’s just helping a teammate, answering
        a question, or passing on a tip in a different field. Don’t let this
        chain stop with you. Let it grow through you.
      </>
    ),
  },
];

function Feature({ Svg, title, description }) {
  return (
    <div className={clsx("col col--4")}>
      <div className="text--center">
        <Svg className={styles.featureSvg} role="img" />
      </div>
      <div className="text--center padding-horiz--md">
        <Heading as="h3">{title}</Heading>
        <p>{description}</p>
      </div>
    </div>
  );
}

export default function HomepageFeatures() {
  return (
    <section className={styles.features}>
      <div className="container">
        <div className="row">
          {FeatureList.map((props, idx) => (
            <Feature key={idx} {...props} />
          ))}
        </div>
      </div>
    </section>
  );
}
